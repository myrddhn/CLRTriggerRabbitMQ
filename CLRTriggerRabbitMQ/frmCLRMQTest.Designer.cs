namespace CLRTriggerRabbitMQ
{
    partial class frmCLRMQTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnUpdateDB = new System.Windows.Forms.Button();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblHostName = new System.Windows.Forms.Label();
            this.lblRTT = new System.Windows.Forms.Label();
            this.lblPing = new System.Windows.Forms.Label();
            this.tmrPing = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Enabled = false;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(0, 215);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(443, 204);
            this.txtLog.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 12);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(419, 20);
            this.txtMessage.TabIndex = 0;
            // 
            // btnUpdateDB
            // 
            this.btnUpdateDB.Location = new System.Drawing.Point(356, 38);
            this.btnUpdateDB.Name = "btnUpdateDB";
            this.btnUpdateDB.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDB.TabIndex = 1;
            this.btnUpdateDB.Text = "Update DB";
            this.btnUpdateDB.UseVisualStyleBackColor = true;
            this.btnUpdateDB.Click += new System.EventHandler(this.btnUpdateDB_Click);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(266, 80);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(80, 13);
            this.lblHost.TabIndex = 3;
            this.lblHost.Text = "RabbitMQ Host";
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHostName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHostName.Location = new System.Drawing.Point(352, 80);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(81, 15);
            this.lblHostName.TabIndex = 4;
            this.lblHostName.Text = "darwinistic.com";
            // 
            // lblRTT
            // 
            this.lblRTT.AutoSize = true;
            this.lblRTT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRTT.Location = new System.Drawing.Point(352, 103);
            this.lblRTT.Name = "lblRTT";
            this.lblRTT.Size = new System.Drawing.Size(25, 15);
            this.lblRTT.TabIndex = 6;
            this.lblRTT.Text = "-ms";
            // 
            // lblPing
            // 
            this.lblPing.AutoSize = true;
            this.lblPing.Location = new System.Drawing.Point(318, 105);
            this.lblPing.Name = "lblPing";
            this.lblPing.Size = new System.Drawing.Size(28, 13);
            this.lblPing.TabIndex = 5;
            this.lblPing.Text = "Ping";
            // 
            // tmrPing
            // 
            this.tmrPing.Interval = 1000;
            this.tmrPing.Tick += new System.EventHandler(this.tmrPing_Tick);
            // 
            // frmCLRMQTest
            // 
            this.AcceptButton = this.btnUpdateDB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 419);
            this.Controls.Add(this.lblRTT);
            this.Controls.Add(this.lblPing);
            this.Controls.Add(this.lblHostName);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.btnUpdateDB);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtLog);
            this.Name = "frmCLRMQTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CLR Trigger to RabbitMQ Test";
            this.Load += new System.EventHandler(this.frmCLRMQTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnUpdateDB;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.Label lblRTT;
        private System.Windows.Forms.Label lblPing;
        private System.Windows.Forms.Timer tmrPing;
    }
}

