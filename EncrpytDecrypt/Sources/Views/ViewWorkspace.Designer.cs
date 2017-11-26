namespace EncrpytDecrypt
{
    partial class Workspace
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
            this.bt_draftsman = new System.Windows.Forms.Button();
            this.bt_OK = new System.Windows.Forms.Button();
            this.bt_new = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_workspace
            // 
            this.lb_workspace.AutoSize = true;
            this.lb_workspace.Location = new System.Drawing.Point(12, 15);
            this.lb_workspace.Name = "lb_workspace";
            this.lb_workspace.Size = new System.Drawing.Size(65, 13);
            this.lb_workspace.TabIndex = 0;
            this.lb_workspace.Text = "Workspace:";
            // 
            // tbx_workspace
            // 
            this.tbx_workspace.Location = new System.Drawing.Point(83, 12);
            this.tbx_workspace.Name = "tbx_workspace";
            this.tbx_workspace.Size = new System.Drawing.Size(255, 20);
            this.tbx_workspace.TabIndex = 1;
            // 
            // bt_chooseWorkspace
            // 
            this.bt_chooseWorkspace.Location = new System.Drawing.Point(344, 10);
            this.bt_chooseWorkspace.Name = "bt_chooseWorkspace";
            this.bt_chooseWorkspace.Size = new System.Drawing.Size(34, 23);
            this.bt_chooseWorkspace.TabIndex = 2;
            this.bt_chooseWorkspace.Text = "...";
            this.bt_chooseWorkspace.UseVisualStyleBackColor = true;
            this.bt_chooseWorkspace.Click += new System.EventHandler(this.bt_chooseWorkspace_Click);
            // 
            // bt_draftsman
            // 
            this.bt_draftsman.Location = new System.Drawing.Point(12, 42);
            this.bt_draftsman.Name = "bt_draftsman";
            this.bt_draftsman.Size = new System.Drawing.Size(75, 23);
            this.bt_draftsman.TabIndex = 3;
            this.bt_draftsman.Text = "Über...";
            this.bt_draftsman.UseVisualStyleBackColor = true;
            this.bt_draftsman.Click += new System.EventHandler(this.bt_draftsman_Click);
            // 
            // bt_OK
            // 
            this.bt_OK.Enabled = false;
            this.bt_OK.Location = new System.Drawing.Point(303, 42);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(75, 23);
            this.bt_OK.TabIndex = 3;
            this.bt_OK.Text = "OK";
            this.bt_OK.UseVisualStyleBackColor = true;
            // 
            // bt_new
            // 
            this.bt_new.Location = new System.Drawing.Point(222, 42);
            this.bt_new.Name = "bt_new";
            this.bt_new.Size = new System.Drawing.Size(75, 23);
            this.bt_new.TabIndex = 3;
            this.bt_new.Text = "Neu";
            this.bt_new.UseVisualStyleBackColor = true;
            this.bt_new.Click += new System.EventHandler(this.bt_new_Click);
            // 
            // bt_close
            // 
            this.bt_close.Location = new System.Drawing.Point(141, 42);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(75, 23);
            this.bt_close.TabIndex = 3;
            this.bt_close.Text = "Schließen";
            this.bt_close.UseVisualStyleBackColor = true;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // Workspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 77);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_new);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.bt_draftsman);
            this.Controls.Add(this.bt_chooseWorkspace);
            this.Controls.Add(this.tbx_workspace);
            this.Controls.Add(this.lb_workspace);
            this.Name = "Workspace";
            this.Text = "Workspace wählen ...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_workspace;
        private System.Windows.Forms.TextBox tbx_workspace;
        private System.Windows.Forms.Button bt_chooseWorkspace;
        private System.Windows.Forms.FolderBrowserDialog fbd_chooseWorkspace;
        private System.Windows.Forms.Button bt_draftsman;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.Button bt_new;
        private System.Windows.Forms.Button bt_close;
    }
}

