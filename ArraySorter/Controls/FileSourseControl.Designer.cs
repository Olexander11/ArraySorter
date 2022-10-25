namespace ArraySorter.Controls
{
    partial class FileSourseControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.infoLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.fileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(16, 19);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(109, 16);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "Select source file";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(100, 38);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(88, 32);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(3, 38);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(91, 32);
            this.fileButton.TabIndex = 2;
            this.fileButton.Text = "Open file";
            this.fileButton.UseVisualStyleBackColor = true;
            // 
            // FileSourseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.infoLabel);
            this.Name = "FileSourseControl";
            this.Size = new System.Drawing.Size(205, 96);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ConfirmButton_Click1(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button fileButton;
    }
}
