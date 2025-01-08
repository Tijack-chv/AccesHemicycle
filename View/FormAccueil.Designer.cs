namespace AccesHemiCycle.View
{
    partial class FormAccueil
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
            this.panelBackCamera = new System.Windows.Forms.Panel();
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.labelCamera = new System.Windows.Forms.Label();
            this.textBoxContenu = new System.Windows.Forms.TextBox();
            this.comboBoxCamera = new System.Windows.Forms.ComboBox();
            this.panelBackCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBackCamera
            // 
            this.panelBackCamera.BackColor = System.Drawing.Color.Black;
            this.panelBackCamera.Controls.Add(this.pictureBoxCamera);
            this.panelBackCamera.Location = new System.Drawing.Point(302, 23);
            this.panelBackCamera.Name = "panelBackCamera";
            this.panelBackCamera.Size = new System.Drawing.Size(476, 437);
            this.panelBackCamera.TabIndex = 14;
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.BackColor = System.Drawing.Color.White;
            this.pictureBoxCamera.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(470, 431);
            this.pictureBoxCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCamera.TabIndex = 1;
            this.pictureBoxCamera.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(444, 466);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(83, 41);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Lancer";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonRead.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold);
            this.buttonRead.Location = new System.Drawing.Point(533, 466);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(85, 41);
            this.buttonRead.TabIndex = 12;
            this.buttonRead.Text = "Scan";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // labelCamera
            // 
            this.labelCamera.AutoSize = true;
            this.labelCamera.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCamera.Location = new System.Drawing.Point(807, 23);
            this.labelCamera.Name = "labelCamera";
            this.labelCamera.Size = new System.Drawing.Size(59, 16);
            this.labelCamera.TabIndex = 11;
            this.labelCamera.Text = "Camera :";
            // 
            // textBoxContenu
            // 
            this.textBoxContenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxContenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxContenu.Location = new System.Drawing.Point(845, 97);
            this.textBoxContenu.Multiline = true;
            this.textBoxContenu.Name = "textBoxContenu";
            this.textBoxContenu.Size = new System.Drawing.Size(254, 324);
            this.textBoxContenu.TabIndex = 13;
            // 
            // comboBoxCamera
            // 
            this.comboBoxCamera.FormattingEnabled = true;
            this.comboBoxCamera.Location = new System.Drawing.Point(869, 20);
            this.comboBoxCamera.Name = "comboBoxCamera";
            this.comboBoxCamera.Size = new System.Drawing.Size(230, 21);
            this.comboBoxCamera.TabIndex = 10;
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 523);
            this.Controls.Add(this.panelBackCamera);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.labelCamera);
            this.Controls.Add(this.textBoxContenu);
            this.Controls.Add(this.comboBoxCamera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAccueil";
            this.Text = "FormAccueil";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAccueil_FormClosing);
            this.Load += new System.EventHandler(this.FormAccueil_Load);
            this.panelBackCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBackCamera;
        private System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Label labelCamera;
        private System.Windows.Forms.TextBox textBoxContenu;
        private System.Windows.Forms.ComboBox comboBoxCamera;
    }
}