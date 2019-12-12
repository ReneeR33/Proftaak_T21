namespace SmartBike
{
    partial class FormAddFingerprint
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
            this.checkBoxFirst = new System.Windows.Forms.CheckBox();
            this.checkBoxSecond = new System.Windows.Forms.CheckBox();
            this.checkBoxAdded = new System.Windows.Forms.CheckBox();
            this.button = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxFirst
            // 
            this.checkBoxFirst.AutoCheck = false;
            this.checkBoxFirst.AutoSize = true;
            this.checkBoxFirst.Location = new System.Drawing.Point(21, 35);
            this.checkBoxFirst.Name = "checkBoxFirst";
            this.checkBoxFirst.Size = new System.Drawing.Size(68, 17);
            this.checkBoxFirst.TabIndex = 0;
            this.checkBoxFirst.Text = "first scan";
            this.checkBoxFirst.UseVisualStyleBackColor = true;
            // 
            // checkBoxSecond
            // 
            this.checkBoxSecond.AutoCheck = false;
            this.checkBoxSecond.AutoSize = true;
            this.checkBoxSecond.Location = new System.Drawing.Point(21, 58);
            this.checkBoxSecond.Name = "checkBoxSecond";
            this.checkBoxSecond.Size = new System.Drawing.Size(87, 17);
            this.checkBoxSecond.TabIndex = 1;
            this.checkBoxSecond.Text = "second scan";
            this.checkBoxSecond.UseVisualStyleBackColor = true;
            // 
            // checkBoxAdded
            // 
            this.checkBoxAdded.AutoCheck = false;
            this.checkBoxAdded.AutoSize = true;
            this.checkBoxAdded.Location = new System.Drawing.Point(21, 81);
            this.checkBoxAdded.Name = "checkBoxAdded";
            this.checkBoxAdded.Size = new System.Drawing.Size(105, 17);
            this.checkBoxAdded.TabIndex = 2;
            this.checkBoxAdded.Text = "fingerprint added";
            this.checkBoxAdded.UseVisualStyleBackColor = true;
            // 
            // button
            // 
            this.button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button.Enabled = false;
            this.button.Location = new System.Drawing.Point(112, 113);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(80, 25);
            this.button.TabIndex = 3;
            this.button.Text = "OK";
            this.button.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(108, 9);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(84, 13);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Scan your finger";
            // 
            // FormAddFingerprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 150);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.button);
            this.Controls.Add(this.checkBoxAdded);
            this.Controls.Add(this.checkBoxSecond);
            this.Controls.Add(this.checkBoxFirst);
            this.Name = "FormAddFingerprint";
            this.Text = "FormAddFingerprint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxFirst;
        private System.Windows.Forms.CheckBox checkBoxSecond;
        private System.Windows.Forms.CheckBox checkBoxAdded;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button button;
    }
}