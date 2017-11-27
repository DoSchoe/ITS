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
    public partial class ViewMain : Form,IViewMain
    {
        #region Members
        private IController _controller;
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
        private void ViewMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.closeApplication();
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            _controller.showAbout();
        }
        #endregion
    }
}
