namespace Client
{
    partial class Frm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDoor = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblConnect = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnBrose = new System.Windows.Forms.Button();
            this.lbxServer = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnAskList = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.lblDownload = new System.Windows.Forms.Label();
            this.txtRename = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDoor);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.lblConnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(51, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Porta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(51, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP";
            // 
            // txtDoor
            // 
            this.txtDoor.Location = new System.Drawing.Point(171, 78);
            this.txtDoor.Name = "txtDoor";
            this.txtDoor.Size = new System.Drawing.Size(100, 23);
            this.txtDoor.TabIndex = 3;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(171, 30);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 23);
            this.txtIP.TabIndex = 2;
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Location = new System.Drawing.Point(18, 120);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(68, 30);
            this.lblConnect.TabIndex = 1;
            this.lblConnect.Text = "Ip: 127.0.0.1\r\nPorta 2000";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(171, 120);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 30);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connetti";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPath);
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Controls.Add(this.btnBrose);
            this.groupBox2.Location = new System.Drawing.Point(27, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 182);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Browse";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPath.Location = new System.Drawing.Point(18, 113);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(0, 21);
            this.lblPath.TabIndex = 2;
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpload.Location = new System.Drawing.Point(146, 49);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(73, 38);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnBrose
            // 
            this.btnBrose.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBrose.Location = new System.Drawing.Point(36, 49);
            this.btnBrose.Name = "btnBrose";
            this.btnBrose.Size = new System.Drawing.Size(75, 38);
            this.btnBrose.TabIndex = 0;
            this.btnBrose.Text = "Browse";
            this.btnBrose.UseVisualStyleBackColor = true;
            this.btnBrose.Click += new System.EventHandler(this.btnBrose_Click);
            // 
            // lbxServer
            // 
            this.lbxServer.FormattingEnabled = true;
            this.lbxServer.ItemHeight = 15;
            this.lbxServer.Location = new System.Drawing.Point(356, 57);
            this.lbxServer.Name = "lbxServer";
            this.lbxServer.Size = new System.Drawing.Size(226, 229);
            this.lbxServer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(356, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(356, 297);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnAskList
            // 
            this.btnAskList.Location = new System.Drawing.Point(484, 21);
            this.btnAskList.Name = "btnAskList";
            this.btnAskList.Size = new System.Drawing.Size(98, 30);
            this.btnAskList.TabIndex = 5;
            this.btnAskList.Text = "File List";
            this.btnAskList.UseVisualStyleBackColor = true;
            this.btnAskList.Click += new System.EventHandler(this.btnAskList_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(356, 326);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(356, 366);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 7;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Location = new System.Drawing.Point(456, 299);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(0, 15);
            this.lblDownload.TabIndex = 8;
            // 
            // txtRename
            // 
            this.txtRename.Location = new System.Drawing.Point(443, 366);
            this.txtRename.Name = "txtRename";
            this.txtRename.Size = new System.Drawing.Size(126, 23);
            this.txtRename.TabIndex = 9;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(443, 326);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 10;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 425);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtRename);
            this.Controls.Add(this.lblDownload);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAskList);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxServer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtDoor;
        private TextBox txtIP;
        private Label lblConnect;
        private Button btnConnect;
        private GroupBox groupBox2;
        private Label lblPath;
        private Button btnUpload;
        private Button btnBrose;
        private ListBox lbxServer;
        private Label label1;
        private Button btnDownload;
        private Button btnAskList;
        private Button btnDelete;
        private Button btnRename;
        private Label lblDownload;
        private TextBox txtRename;
        private Button btnCopy;
        private Label label5;
        private Label label3;
    }
}