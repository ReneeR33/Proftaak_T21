namespace SmartBike
{
    partial class FormOwner
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonAddFingerprint = new System.Windows.Forms.Button();
            this.buttonRemoveUser = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLock = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelLocked = new System.Windows.Forms.Label();
            this.labelConnected = new System.Windows.Forms.Label();
            this.groupBoxData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.Map);
            this.groupBoxData.Location = new System.Drawing.Point(31, 41);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(422, 293);
            this.groupBoxData.TabIndex = 1;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "data bike";
            // 
            // Map
            // 
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemmory = 5;
            this.Map.Location = new System.Drawing.Point(15, 19);
            this.Map.MarkersEnabled = true;
            this.Map.MaxZoom = 2;
            this.Map.MinZoom = 2;
            this.Map.MouseWheelZoomEnabled = true;
            this.Map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Map.Name = "Map";
            this.Map.NegativeMode = false;
            this.Map.PolygonsEnabled = true;
            this.Map.RetryLoadTile = 0;
            this.Map.RoutesEnabled = true;
            this.Map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Map.ShowTileGridLines = false;
            this.Map.Size = new System.Drawing.Size(401, 268);
            this.Map.TabIndex = 0;
            this.Map.Zoom = 0D;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.buttonAddFingerprint);
            this.groupBox1.Controls.Add(this.buttonRemoveUser);
            this.groupBox1.Controls.Add(this.buttonAddUser);
            this.groupBox1.Controls.Add(this.listBoxUsers);
            this.groupBox1.Location = new System.Drawing.Point(471, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 379);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "users";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(22, 139);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 22);
            this.button5.TabIndex = 15;
            this.button5.Text = "change name";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(22, 236);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 22);
            this.button4.TabIndex = 14;
            this.button4.Text = "give access";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(22, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 22);
            this.button3.TabIndex = 13;
            this.button3.Text = "change username";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(22, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 22);
            this.button2.TabIndex = 12;
            this.button2.Text = "change password";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "access to bike";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(481, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(142, 290);
            this.listBox1.TabIndex = 10;
            // 
            // buttonAddFingerprint
            // 
            this.buttonAddFingerprint.Enabled = false;
            this.buttonAddFingerprint.Location = new System.Drawing.Point(22, 112);
            this.buttonAddFingerprint.Name = "buttonAddFingerprint";
            this.buttonAddFingerprint.Size = new System.Drawing.Size(102, 22);
            this.buttonAddFingerprint.TabIndex = 3;
            this.buttonAddFingerprint.Text = "add fingerprint";
            this.buttonAddFingerprint.UseVisualStyleBackColor = true;
            this.buttonAddFingerprint.Click += new System.EventHandler(this.ButtonAddFingerprint_Click);
            // 
            // buttonRemoveUser
            // 
            this.buttonRemoveUser.Location = new System.Drawing.Point(22, 63);
            this.buttonRemoveUser.Name = "buttonRemoveUser";
            this.buttonRemoveUser.Size = new System.Drawing.Size(102, 22);
            this.buttonRemoveUser.TabIndex = 2;
            this.buttonRemoveUser.Text = "remove user";
            this.buttonRemoveUser.UseVisualStyleBackColor = true;
            this.buttonRemoveUser.Click += new System.EventHandler(this.ButtonRemoveUser_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(22, 35);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(102, 22);
            this.buttonAddUser.TabIndex = 1;
            this.buttonAddUser.Text = "add user";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.ButtonAddUser_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(141, 35);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(334, 290);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.ListBoxUsers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "username";
            // 
            // buttonLock
            // 
            this.buttonLock.Location = new System.Drawing.Point(31, 358);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(105, 24);
            this.buttonLock.TabIndex = 6;
            this.buttonLock.Text = "open lock";
            this.buttonLock.UseVisualStyleBackColor = true;
            this.buttonLock.Click += new System.EventHandler(this.ButtonLock_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(96, 7);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(79, 22);
            this.buttonLogout.TabIndex = 4;
            this.buttonLogout.Text = "logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // labelLocked
            // 
            this.labelLocked.AutoSize = true;
            this.labelLocked.Location = new System.Drawing.Point(28, 248);
            this.labelLocked.Name = "labelLocked";
            this.labelLocked.Size = new System.Drawing.Size(10, 13);
            this.labelLocked.TabIndex = 8;
            this.labelLocked.Text = ".";
            // 
            // labelConnected
            // 
            this.labelConnected.AutoSize = true;
            this.labelConnected.Location = new System.Drawing.Point(198, 12);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(58, 13);
            this.labelConnected.TabIndex = 9;
            this.labelConnected.Text = "connected";
            // 
            // FormOwner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 411);
            this.Controls.Add(this.labelConnected);
            this.Controls.Add(this.labelLocked);
            this.Controls.Add(this.buttonLock);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxData);
            this.Name = "FormOwner";
            this.Text = "Form1";
            this.groupBoxData.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Button buttonRemoveUser;
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label labelLocked;
        private System.Windows.Forms.Label labelConnected;
        private System.Windows.Forms.Button buttonAddFingerprint;
        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
    }
}

