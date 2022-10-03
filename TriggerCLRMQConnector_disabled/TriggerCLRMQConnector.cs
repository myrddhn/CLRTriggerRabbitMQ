using EasyNetQ;
using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlClient;
using Messages;

public partial class CLRTriggers
{
    static SqlPipe MessagePipe;
    private static void submitMessage(string msg)
    {
        using (var bus = RabbitHutch.CreateBus("host=pcwue029;virtualHost=artest;username=andi;password=idna"))
        {
            bus.Advanced.QueueDeclarePassive("testqueue");
            bus.PubSub.Publish(new TextMessage { Text = msg }, "testqueue");
            MessagePipe.Send("Message published!");
        }
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
        var msg = dr["message"].ToString();

        MessagePipe.Send(msg);
        submitMessage(msg);
        
        dr.Close();
        conn.Close();
    }
}
