using EasyNetQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SubMessage;

namespace CLRTriggerRabbitMQ
{
    public partial class frmCLRMQTest : Form
    {
        string connstring = @"Data Source=mssql.darwinistic.com;Initial Catalog=TriggerMQTest;user=sa;password=Wizardkatja1";
        SqlConnection conn;
        SqlCommand cmd;
        SqlParameter sqlParameter;
        static IBus bus;

        public void logMessage(string msg)
        {
            txtLog.AppendText($"[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")}] - {msg}\r\n");
            txtLog.ScrollToCaret();
        }
        public frmCLRMQTest()
        {
            InitializeComponent();
        }

        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            logMessage($"Updating table with '{txtMessage.Text}'");
            sqlParameter.Value = txtMessage.Text;
            cmd.ExecuteNonQuery();
            txtMessage.SelectAll();
            txtMessage.Focus();
        }

        public void HandleTextMessage(SubTextMessage textMessage)
        {
            Invoke(new Action(() => {logMessage($"Message from MQ: {textMessage.Text.Trim()}");}));
        }

        private void frmCLRMQTest_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            logMessage("Connected to DB");
            cmd = conn.CreateCommand();
            cmd.CommandText = ("UPDATE QueueData SET message = @msg WHERE \"queue\" = '/trigger/two'");
            sqlParameter = new SqlParameter("msg", "");
            logMessage("Query created");
            cmd.Parameters.Add(sqlParameter);

            bus = RabbitHutch.CreateBus("host=darwinistic.com;virtualHost=artest;username=andi;password=idna");
            logMessage("Bus created");

            bus.Advanced.QueueDeclarePassive("testqueue");
            bus.PubSub.Subscribe<SubTextMessage>("", HandleTextMessage, x => x.WithTopic("testqueue"));

            logMessage("Subscribed to queue/topic");
        }
    }
}
