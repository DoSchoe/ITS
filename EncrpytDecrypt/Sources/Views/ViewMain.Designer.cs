namespace EncrpytDecrypt
{
    partial class ViewMain
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
            this.tlp_viewMain = new System.Windows.Forms.TableLayoutPanel();
            this.lb_keyHandling = new System.Windows.Forms.Label();
            this.bt_createRsaKeys = new System.Windows.Forms.Button();
            this.bt_exportPublicRsaKey = new System.Windows.Forms.Button();
            this.lb_fileHandling = new System.Windows.Forms.Label();
            this.bt_encrypt = new System.Windows.Forms.Button();
            this.bt_decrypt = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_clearRoot = new System.Windows.Forms.Button();
            this.tbx_logFile = new System.Windows.Forms.TextBox();
            this.lb_logFile = new System.Windows.Forms.Label();
            this.bt_about = new System.Windows.Forms.Button();
            this.tlp_viewMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_viewMain
            // 
            this.tlp_viewMain.ColumnCount = 3;
            this.tlp_viewMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tlp_viewMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlp_viewMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tlp_viewMain.Controls.Add(this.lb_keyHandling, 0, 0);
            this.tlp_viewMain.Controls.Add(this.bt_createRsaKeys, 0, 1);
            this.tlp_viewMain.Controls.Add(this.bt_exportPublicRsaKey, 2, 1);
            this.tlp_viewMain.Controls.Add(this.lb_fileHandling, 0, 3);
            this.tlp_viewMain.Controls.Add(this.bt_encrypt, 0, 4);
            this.tlp_viewMain.Controls.Add(this.bt_decrypt, 2, 4);
            this.tlp_viewMain.Controls.Add(this.bt_close, 2, 6);
            this.tlp_viewMain.Controls.Add(this.bt_clearRoot, 0, 6);
            this.tlp_viewMain.Controls.Add(this.tbx_logFile, 1, 9);
            this.tlp_viewMain.Controls.Add(this.lb_logFile, 0, 9);
            this.tlp_viewMain.Controls.Add(this.bt_about, 2, 8);
            this.tlp_viewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_viewMain.Location = new System.Drawing.Point(0, 0);
            this.tlp_viewMain.Name = "tlp_viewMain";
            this.tlp_viewMain.RowCount = 10;
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_viewMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_viewMain.Size = new System.Drawing.Size(489, 532);
            this.tlp_viewMain.TabIndex = 0;
            // 
            // lb_keyHandling
            // 
            this.lb_keyHandling.AutoSize = true;
            this.tlp_viewMain.SetColumnSpan(this.lb_keyHandling, 3);
            this.lb_keyHandling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_keyHandling.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_keyHandling.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lb_keyHandling.Location = new System.Drawing.Point(3, 0);
            this.lb_keyHandling.Name = "lb_keyHandling";
            this.lb_keyHandling.Size = new System.Drawing.Size(483, 25);
            this.lb_keyHandling.TabIndex = 0;
            this.lb_keyHandling.Text = "RSA-key handling";
            // 
            // bt_createRsaKeys
            // 
            this.bt_createRsaKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_createRsaKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_createRsaKeys.Location = new System.Drawing.Point(3, 28);
            this.bt_createRsaKeys.Name = "bt_createRsaKeys";
            this.bt_createRsaKeys.Size = new System.Drawing.Size(223, 29);
            this.bt_createRsaKeys.TabIndex = 1;
            this.bt_createRsaKeys.Text = "Create asym. RSA-keys";
            this.bt_createRsaKeys.UseVisualStyleBackColor = true;
            this.bt_createRsaKeys.Click += new System.EventHandler(this.bt_createRsaKeys_Click);
            // 
            // bt_exportPublicRsaKey
            // 
            this.bt_exportPublicRsaKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_exportPublicRsaKey.Enabled = false;
            this.bt_exportPublicRsaKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_exportPublicRsaKey.Location = new System.Drawing.Point(261, 28);
            this.bt_exportPublicRsaKey.Name = "bt_exportPublicRsaKey";
            this.bt_exportPublicRsaKey.Size = new System.Drawing.Size(225, 29);
            this.bt_exportPublicRsaKey.TabIndex = 2;
            this.bt_exportPublicRsaKey.Text = "Export public RSA-key";
            this.bt_exportPublicRsaKey.UseVisualStyleBackColor = true;
            this.bt_exportPublicRsaKey.Click += new System.EventHandler(this.bt_exportPublicRsaKey_Click);
            // 
            // lb_fileHandling
            // 
            this.lb_fileHandling.AutoSize = true;
            this.tlp_viewMain.SetColumnSpan(this.lb_fileHandling, 3);
            this.lb_fileHandling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_fileHandling.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fileHandling.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lb_fileHandling.Location = new System.Drawing.Point(3, 72);
            this.lb_fileHandling.Name = "lb_fileHandling";
            this.lb_fileHandling.Size = new System.Drawing.Size(483, 25);
            this.lb_fileHandling.TabIndex = 0;
            this.lb_fileHandling.Text = "File handling";
            // 
            // bt_encrypt
            // 
            this.bt_encrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_encrypt.Enabled = false;
            this.bt_encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_encrypt.ForeColor = System.Drawing.Color.Red;
            this.bt_encrypt.Location = new System.Drawing.Point(3, 100);
            this.bt_encrypt.Name = "bt_encrypt";
            this.bt_encrypt.Size = new System.Drawing.Size(223, 29);
            this.bt_encrypt.TabIndex = 3;
            this.bt_encrypt.Text = "Encrypt a file";
            this.bt_encrypt.UseVisualStyleBackColor = true;
            // 
            // bt_decrypt
            // 
            this.bt_decrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_decrypt.Enabled = false;
            this.bt_decrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_decrypt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bt_decrypt.Location = new System.Drawing.Point(261, 100);
            this.bt_decrypt.Name = "bt_decrypt";
            this.bt_decrypt.Size = new System.Drawing.Size(225, 29);
            this.bt_decrypt.TabIndex = 4;
            this.bt_decrypt.Text = "Decrypt a file";
            this.bt_decrypt.UseVisualStyleBackColor = true;
            // 
            // bt_close
            // 
            this.bt_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_close.Location = new System.Drawing.Point(261, 147);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(225, 29);
            this.bt_close.TabIndex = 6;
            this.bt_close.Text = "Close";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // bt_clearRoot
            // 
            this.bt_clearRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_clearRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_clearRoot.Location = new System.Drawing.Point(3, 147);
            this.bt_clearRoot.Name = "bt_clearRoot";
            this.bt_clearRoot.Size = new System.Drawing.Size(223, 29);
            this.bt_clearRoot.TabIndex = 5;
            this.bt_clearRoot.Text = "Clear all files";
            this.bt_clearRoot.UseVisualStyleBackColor = true;
            // 
            // tbx_logFile
            // 
            this.tlp_viewMain.SetColumnSpan(this.tbx_logFile, 3);
            this.tbx_logFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_logFile.Location = new System.Drawing.Point(3, 252);
            this.tbx_logFile.Multiline = true;
            this.tbx_logFile.Name = "tbx_logFile";
            this.tbx_logFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx_logFile.Size = new System.Drawing.Size(483, 277);
            this.tbx_logFile.TabIndex = 7;
            // 
            // lb_logFile
            // 
            this.lb_logFile.AutoSize = true;
            this.lb_logFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_logFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_logFile.Location = new System.Drawing.Point(3, 236);
            this.lb_logFile.Name = "lb_logFile";
            this.lb_logFile.Size = new System.Drawing.Size(223, 13);
            this.lb_logFile.TabIndex = 8;
            this.lb_logFile.Text = "Log file:";
            // 
            // bt_about
            // 
            this.bt_about.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_about.Location = new System.Drawing.Point(261, 194);
            this.bt_about.Name = "bt_about";
            this.bt_about.Size = new System.Drawing.Size(225, 29);
            this.bt_about.TabIndex = 9;
            this.bt_about.Text = "About...";
            this.bt_about.UseVisualStyleBackColor = true;
            this.bt_about.Click += new System.EventHandler(this.bt_about_Click);
            // 
            // ViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 532);
            this.Controls.Add(this.tlp_viewMain);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(505, 571);
            this.Name = "ViewMain";
            this.Text = "RSA Encryption & Decryption";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewMain_FormClosing);
            this.tlp_viewMain.ResumeLayout(false);
            this.tlp_viewMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_viewMain;
        private System.Windows.Forms.Label lb_keyHandling;
        private System.Windows.Forms.Button bt_createRsaKeys;
        private System.Windows.Forms.Button bt_exportPublicRsaKey;
        private System.Windows.Forms.Label lb_fileHandling;
        private System.Windows.Forms.Button bt_encrypt;
        private System.Windows.Forms.Button bt_decrypt;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Button bt_clearRoot;
        private System.Windows.Forms.TextBox tbx_logFile;
        private System.Windows.Forms.Label lb_logFile;
        private System.Windows.Forms.Button bt_about;
    }
}