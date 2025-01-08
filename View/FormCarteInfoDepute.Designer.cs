namespace AccesHemiCycle.View
{
    partial class FormCarteInfoDepute
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
            this.pictureBoxDepute = new System.Windows.Forms.PictureBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepute)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDepute
            // 
            this.pictureBoxDepute.Location = new System.Drawing.Point(57, 12);
            this.pictureBoxDepute.Name = "pictureBoxDepute";
            this.pictureBoxDepute.Size = new System.Drawing.Size(340, 304);
            this.pictureBoxDepute.TabIndex = 0;
            this.pictureBoxDepute.TabStop = false;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.labelFirstName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelFirstName.Location = new System.Drawing.Point(192, 358);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(70, 21);
            this.labelFirstName.TabIndex = 1;
            this.labelFirstName.Text = "Prénom";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelName.Location = new System.Drawing.Point(203, 331);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(48, 21);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Nom";
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.labelMail.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelMail.Location = new System.Drawing.Point(201, 385);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(53, 21);
            this.labelMail.TabIndex = 3;
            this.labelMail.Text = "Email";
            // 
            // FormCarteInfoDepute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(476, 437);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.pictureBoxDepute);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCarteInfoDepute";
            this.Text = "FormCarteInfoDepute";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDepute;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelMail;
    }
}