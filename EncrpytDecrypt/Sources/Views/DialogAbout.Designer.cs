namespace EncrpytDecrypt
{
    partial class DialogAbout
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
            this.lb_draftsman = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_draftsman
            // 
            this.lb_draftsman.AutoSize = true;
            this.lb_draftsman.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_draftsman.Location = new System.Drawing.Point(13, 13);
            this.lb_draftsman.Name = "lb_draftsman";
            this.lb_draftsman.Size = new System.Drawing.Size(303, 40);
            this.lb_draftsman.TabIndex = 0;
            this.lb_draftsman.Text = "Christopher Neuwirt, S1610564013\r\nDominik Schönberger, S1610564017";
            // 
            // DialogAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 64);
            this.Controls.Add(this.lb_draftsman);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DialogAbout";
            this.Text = "Developer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_draftsman;
    }
}