using PubMessage;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

public partial class CLRTriggers
{
    static SqlPipe MessagePipe;
    private static void publishMessage(PubTextMessage msg)
    {
        MessagePipe.Send("In publishMessage()");
        // 108.161.136.198 = darwinistic.com; save the DNS lookup
        string url = "http://108.161.136.198:15672/api/exchanges/artest//publish";
        string strPayload = JsonConvert.SerializeObject(msg).Replace("\"", "\\\"");
        MessagePipe.Send("strPayload: " + strPayload);

        string payload = $"{{\"properties\":{{ \"type\":\"SubMessage.SubTextMessage, SubMessage\" }},\"routing_key\":\"testqueue\",\"payload\":\"{strPayload}\",\"payload_encoding\":\"string\"}}";

        MessagePipe.Send("Payload: " + payload);

        var httpc = new HttpClient();
        httpc.DefaultRequestHeaders.Add("User-Agent", "CLR Trigger");
        httpc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var hrequest = new HttpRequestMessage(HttpMethod.Post, url);
        var b64auth = Convert.ToBase64String(Encoding.ASCII.GetBytes("andi:idna"));
        var content = new StringContent(payload, Encoding.UTF8, "application/json");
        hrequest.Headers.Add("Authorization", "Basic " + b64auth);
        hrequest.Headers.Add("Accept", "application/json");
        hrequest.Content = content;

        MessagePipe.Send("Doing POST");
        var ret = httpc.SendAsync(hrequest).Result;
        MessagePipe.Send("Return from POST");

        var rs = ret.Content.ReadAsStringAsync().Result;

        MessagePipe.Send("Status code: " + ret.StatusCode);
        MessagePipe.Send("Response: " + rs);
        MessagePipe.Send($"Published: {JsonConvert.SerializeObject(msg)}");
    }

    [SqlTrigger(
        Name = "QueueTrigger",
        Target = "QueueData",
        Event = "FOR UPDATE")
    ]
    public static void QueueTrigger()
    {
        SqlConnection conn = new SqlConnection("context connection = true");
        conn.Open();
        MessagePipe = SqlContext.Pipe;

        SqlCommand cmd = new SqlCommand("SELECT message FROM INSERTED", conn);
        SqlDataReader dr = cmd.ExecuteReader();

        dr.Read();
        var text = dr["message"].ToString();

        MessagePipe.Send("publishting message");
        var msg = new PubTextMessage { Text = text };
        publishMessage(msg);
        MessagePipe.Send(JsonConvert.SerializeObject(msg));

        dr.Close();
        conn.Close();
    }
}
