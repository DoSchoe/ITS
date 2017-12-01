using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncrpytDecrypt
{
    public partial class ViewMain : Form,IViewMain,IModelObserverMain
    {
        #region Members
        private IController _controller;
        public event ViewMainHandler<IViewMain> createRsaKeys;
        public event ViewMainHandler<IViewMain> exportRsaKey; 
        #endregion

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

        #region Main events
        private void bt_createRsaKeys_Click(object sender, EventArgs e)
        {
            createRsaKeys.Invoke(this, null);
        }
        private void bt_exportPublicRsaKey_Click(object sender, EventArgs e)
        {
            exportRsaKey.Invoke(this, null);
        }
        #endregion
        #endregion

        #region Observers
        /// <summary>
        /// Main view observer for the model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void logUpdated(IModel model, ModelEventArgs e)
        {
            tbx_logFile.AppendText(e.value + "\n");
        }

        public void rsaKeysCreated(IModel model, ModelEventArgs e)
        {
            bt_exportPublicRsaKey.Enabled = true;
            bt_decrypt.Enabled = true;
            bt_encrypt.Enabled = true;
        }
        #endregion

        public void updateLogFile(string msg)
        {
            tbx_logFile.AppendText(msg + "\n");
        }
    }
}
