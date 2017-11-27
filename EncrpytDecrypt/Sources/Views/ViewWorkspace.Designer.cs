namespace EncrpytDecrypt
{
    partial class ViewWorkspace
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_workspace = new System.Windows.Forms.Label();
            this.tbx_workspace = new System.Windows.Forms.TextBox();
            this.bt_chooseWorkspace = new System.Windows.Forms.Button();
            this.fbd_chooseWorkspace = new System.Windows.Forms.FolderBrowserDialog();
            this.bt_about = new System.Windows.Forms.Button();
            this.bt_OK = new System.Windows.Forms.Button();
            this.bt_new = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_workspace
            // 
            this.lb_workspace.AutoSize = true;
            this.lb_workspace.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_workspace.Location = new System.Drawing.Point(14, 13);
            this.lb_workspace.Name = "lb_workspace";
            this.lb_workspace.Size = new System.Drawing.Size(72, 19);
            this.lb_workspace.TabIndex = 0;
            this.lb_workspace.Text = "Directory:";
            // 
            // tbx_workspace
            // 
            this.tbx_workspace.Location = new System.Drawing.Point(97, 14);
            this.tbx_workspace.Name = "tbx_workspace";
            this.tbx_workspace.Size = new System.Drawing.Size(297, 23);
            this.tbx_workspace.TabIndex = 1;
            // 
            // bt_chooseWorkspace
            // 
            this.bt_chooseWorkspace.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_chooseWorkspace.Location = new System.Drawing.Point(401, 12);
            this.bt_chooseWorkspace.Name = "bt_chooseWorkspace";
            this.bt_chooseWorkspace.Size = new System.Drawing.Size(40, 27);
            this.bt_chooseWorkspace.TabIndex = 2;
            this.bt_chooseWorkspace.Text = "...";
            this.bt_chooseWorkspace.UseVisualStyleBackColor = true;
            this.bt_chooseWorkspace.Click += new System.EventHandler(this.bt_chooseWorkspace_Click);
            // 
            // bt_about
            // 
            this.bt_about.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_about.Location = new System.Drawing.Point(14, 48);
            this.bt_about.Name = "bt_about";
            this.bt_about.Size = new System.Drawing.Size(87, 27);
            this.bt_about.TabIndex = 3;
            this.bt_about.Text = "About...";
            this.bt_about.UseVisualStyleBackColor = true;
            this.bt_about.Click += new System.EventHandler(this.bt_draftsman_Click);
            // 
            // bt_OK
            // 
            this.bt_OK.Enabled = false;
            this.bt_OK.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_OK.Location = new System.Drawing.Point(353, 48);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(87, 27);
            this.bt_OK.TabIndex = 3;
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // bt_new
            // 
            this.bt_new.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_new.Location = new System.Drawing.Point(259, 48);
            this.bt_new.Name = "bt_new";
            this.bt_new.Size = new System.Drawing.Size(87, 27);
            this.bt_new.TabIndex = 3;
            this.bt_new.Text = "New";
            this.bt_new.UseVisualStyleBackColor = true;
            this.bt_new.Click += new System.EventHandler(this.bt_new_Click);
            // 
            // bt_close
            // 
            this.bt_close.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_close.Location = new System.Drawing.Point(164, 48);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(87, 27);
            this.bt_close.TabIndex = 3;
            this.bt_close.Text = "Close";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // ViewWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 89);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_new);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.bt_about);
            this.Controls.Add(this.bt_chooseWorkspace);
            this.Controls.Add(this.tbx_workspace);
            this.Controls.Add(this.lb_workspace);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ViewWorkspace";
            this.Text = "Choose directory...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewWorkspace_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_workspace;
        private System.Windows.Forms.TextBox tbx_workspace;
        private System.Windows.Forms.Button bt_chooseWorkspace;
        private System.Windows.Forms.FolderBrowserDialog fbd_chooseWorkspace;
        private System.Windows.Forms.Button bt_about;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.Button bt_new;
        private System.Windows.Forms.Button bt_close;
    }
}

