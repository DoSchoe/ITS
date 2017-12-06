using System;
using System.Windows.Forms;

namespace EncrpytDecrypt
{
    public partial class ViewMain : Form,IViewMain,IModelObserverMain
    {
        #region Members
        private IController _controller;
        public event ViewMainHandler<IViewMain> createRsaKeys;
        public event ViewMainHandler<IViewMain> exportRsaKey;
        public event FileHandler<IViewMain> encryptFile;
        public event FileHandler<IViewMain> decryptFile; 
        public event ViewMainHandler<IViewMain> deleteAllFiles; 
        #endregion

        /// <summary>
        /// CTor
        /// </summary>
        public ViewMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the controller
        /// </summary>
        /// <param name="controller"></param>
        public void setController(IController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Shows the form
        /// </summary>
        public void showMe()
        {
            this.Show();
        }

        /// <summary>
        /// Updates the log-file
        /// </summary>
        /// <param name="msg"></param>
        public void updateLogFile(string msg)
        {
            tbx_logFile.AppendText(msg + "\n");
        }

        #region Form events
        #region General events
        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ViewMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.closeApplication();
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            _controller.showAbout();
        }
        #endregion

        #region Main view events
        private void bt_createRsaKeys_Click(object sender, EventArgs e)
        {
            createRsaKeys.Invoke(this, null);
        }
        private void bt_exportPublicRsaKey_Click(object sender, EventArgs e)
        {
            exportRsaKey.Invoke(this, null);
        }
        private void bt_encrypt_Click(object sender, EventArgs e)
        {
            ofd_chooseFile.Filter = "";
            ofd_chooseFile.InitialDirectory = Model.Instance.getWorkspacePath() + "\\00_Documents";
            DialogResult result = ofd_chooseFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                encryptFile.Invoke(this, new FileEventArgs(ofd_chooseFile.FileNames[0]));
            }
        }
        private void bt_decrypt_Click(object sender, EventArgs e)
        {
            ofd_chooseFile.Filter = "enc files (*.enc)|*.enc";
            ofd_chooseFile.InitialDirectory = Model.Instance.getWorkspacePath() + "\\01_Encrypt";
            DialogResult result = ofd_chooseFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                decryptFile.Invoke(this, new FileEventArgs(ofd_chooseFile.FileNames[0]));
            }
        }
        private void bt_clearRoot_Click(object sender, EventArgs e)
        {
            deleteAllFiles.Invoke(this, null);
        }
        #endregion
        #endregion

        #region Observers
        /// <summary>
        /// Log-file observer for the model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void logUpdated(IModel model, ModelEventArgs e)
        {
            tbx_logFile.AppendText(e.value + "\n");
        }

        /// <summary>
        /// Observer if a RSA-key pair is created
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void rsaKeysCreated(IModel model, ModelEventArgs e)
        {
            bt_exportPublicRsaKey.Enabled = true;
            bt_decrypt.Enabled = true;
            bt_encrypt.Enabled = true;
        }

        /// <summary>
        /// Observer if a public RSA-key is loaded
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void publicRsaKeyLoaded(IModel model, ModelEventArgs e)
        {
            //It is not possible to do anything only with the public key!
            //bt_decrypt.Enabled = true;
        }
        #endregion
    }
}
