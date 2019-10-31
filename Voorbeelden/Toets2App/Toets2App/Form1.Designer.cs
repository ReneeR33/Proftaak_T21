namespace Toets2App
{
    partial class Form1
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
            this.buttonManual = new System.Windows.Forms.Button();
            this.buttonAutomatic = new System.Windows.Forms.Button();
            this.buttonSignalling = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelAmountOfCars1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTime1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelCurrentMode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCarsRemaining = new System.Windows.Forms.Label();
            this.buttonGreen1 = new System.Windows.Forms.Button();
            this.buttonGreen2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonManual
            // 
            this.buttonManual.Location = new System.Drawing.Point(30, 89);
            this.buttonManual.Margin = new System.Windows.Forms.Padding(2);
            this.buttonManual.Name = "buttonManual";
            this.buttonManual.Size = new System.Drawing.Size(92, 27);
            this.buttonManual.TabIndex = 0;
            this.buttonManual.Text = "MANUAL";
            this.buttonManual.UseVisualStyleBackColor = true;
            this.buttonManual.Click += new System.EventHandler(this.buttonManual_Click);
            // 
            // buttonAutomatic
            // 
            this.buttonAutomatic.Location = new System.Drawing.Point(30, 130);
            this.buttonAutomatic.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAutomatic.Name = "buttonAutomatic";
            this.buttonAutomatic.Size = new System.Drawing.Size(88, 27);
            this.buttonAutomatic.TabIndex = 1;
            this.buttonAutomatic.Text = "AUTOMATIC";
            this.buttonAutomatic.UseVisualStyleBackColor = true;
            this.buttonAutomatic.Click += new System.EventHandler(this.buttonAutomatic_Click);
            // 
            // buttonSignalling
            // 
            this.buttonSignalling.Location = new System.Drawing.Point(30, 173);
            this.buttonSignalling.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSignalling.Name = "buttonSignalling";
            this.buttonSignalling.Size = new System.Drawing.Size(88, 27);
            this.buttonSignalling.TabIndex = 2;
            this.buttonSignalling.Text = "SIGNALLING";
            this.buttonSignalling.UseVisualStyleBackColor = true;
            this.buttonSignalling.Click += new System.EventHandler(this.buttonSignalling_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Lane 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lane 2";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Toets2App.Properties.Resources.stoplichten_rood;
            this.pictureBox2.Location = new System.Drawing.Point(419, 52);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(137, 216);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Toets2App.Properties.Resources.stoplichten_rood;
            this.pictureBox1.Location = new System.Drawing.Point(195, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount of cars on lane:";
            // 
            // labelAmountOfCars1
            // 
            this.labelAmountOfCars1.AutoSize = true;
            this.labelAmountOfCars1.Location = new System.Drawing.Point(167, 289);
            this.labelAmountOfCars1.Name = "labelAmountOfCars1";
            this.labelAmountOfCars1.Size = new System.Drawing.Size(13, 13);
            this.labelAmountOfCars1.TabIndex = 9;
            this.labelAmountOfCars1.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Time remaining:";
            // 
            // labelTime1
            // 
            this.labelTime1.AutoSize = true;
            this.labelTime1.Location = new System.Drawing.Point(167, 314);
            this.labelTime1.Name = "labelTime1";
            this.labelTime1.Size = new System.Drawing.Size(59, 13);
            this.labelTime1.TabIndex = 12;
            this.labelTime1.Text = "0  seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Mode:";
            // 
            // labelCurrentMode
            // 
            this.labelCurrentMode.AutoSize = true;
            this.labelCurrentMode.Location = new System.Drawing.Point(68, 24);
            this.labelCurrentMode.Name = "labelCurrentMode";
            this.labelCurrentMode.Size = new System.Drawing.Size(42, 13);
            this.labelCurrentMode.TabIndex = 16;
            this.labelCurrentMode.Text = "Manual";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Cars remaining:";
            // 
            // labelCarsRemaining
            // 
            this.labelCarsRemaining.AutoSize = true;
            this.labelCarsRemaining.Location = new System.Drawing.Point(167, 340);
            this.labelCarsRemaining.Name = "labelCarsRemaining";
            this.labelCarsRemaining.Size = new System.Drawing.Size(13, 13);
            this.labelCarsRemaining.TabIndex = 18;
            this.labelCarsRemaining.Text = "0";
            // 
            // buttonGreen1
            // 
            this.buttonGreen1.Location = new System.Drawing.Point(222, 274);
            this.buttonGreen1.Name = "buttonGreen1";
            this.buttonGreen1.Size = new System.Drawing.Size(77, 30);
            this.buttonGreen1.TabIndex = 19;
            this.buttonGreen1.Text = "green";
            this.buttonGreen1.UseVisualStyleBackColor = true;
            this.buttonGreen1.Click += new System.EventHandler(this.buttonGreen1_Click);
            // 
            // buttonGreen2
            // 
            this.buttonGreen2.Location = new System.Drawing.Point(447, 272);
            this.buttonGreen2.Name = "buttonGreen2";
            this.buttonGreen2.Size = new System.Drawing.Size(77, 30);
            this.buttonGreen2.TabIndex = 20;
            this.buttonGreen2.Text = "green";
            this.buttonGreen2.UseVisualStyleBackColor = true;
            this.buttonGreen2.Click += new System.EventHandler(this.buttonGreen2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 216);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 27);
            this.button1.TabIndex = 21;
            this.button1.Text = "CALAMITY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 372);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGreen2);
            this.Controls.Add(this.buttonGreen1);
            this.Controls.Add(this.labelCarsRemaining);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelCurrentMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelTime1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAmountOfCars1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSignalling);
            this.Controls.Add(this.buttonAutomatic);
            this.Controls.Add(this.buttonManual);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonManual;
        private System.Windows.Forms.Button buttonAutomatic;
        private System.Windows.Forms.Button buttonSignalling;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelAmountOfCars1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTime1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelCurrentMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCarsRemaining;
        private System.Windows.Forms.Button buttonGreen1;
        private System.Windows.Forms.Button buttonGreen2;
        private System.Windows.Forms.Button button1;
    }
}

