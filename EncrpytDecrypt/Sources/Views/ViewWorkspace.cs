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
    public partial class Workspace : Form,IViewWorkspace,IModelWorkspaceObserver
    {
        #region Members
        private IControllerWorkspace _controller;
        public event ViewWorkspaceHandler<IViewWorkspace> rootpathChanged;
        #endregion


        public Workspace()
        {
            InitializeComponent();
        }

        public void setController(IControllerWorkspace controller)
        {
            _controller = controller;
        }

        #region Form-Events
        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void bt_draftsman_Click(object sender, EventArgs e)
        {
            DialogDraftsman draftsman = new DialogDraftsman();
            draftsman.ShowDialog();
        }

        private void bt_chooseWorkspace_Click(object sender, EventArgs e)
        {
            fbd_chooseWorkspace.ShowNewFolderButton = false;
            DialogResult result = fbd_chooseWorkspace.ShowDialog();
            if (result == DialogResult.OK)
            {
                _controller.chooseWorkspace(fbd_chooseWorkspace.SelectedPath);
            }
        }

        private void bt_new_Click(object sender, EventArgs e)
        {
            fbd_chooseWorkspace.ShowNewFolderButton = true;
            DialogResult result = fbd_chooseWorkspace.ShowDialog();
            if (result == DialogResult.OK)
            {
                _controller.createNewWorkspace(fbd_chooseWorkspace.SelectedPath);
            }
        }

        private void tbx_workspace_TextChanged(object sender, EventArgs e)
        {
            rootpathChanged.Invoke(this,new ViewEventArgs(tbx_workspace.Text));
        }
        #endregion

        /// <summary>
        /// Observer for the model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void rootpathSet(IModelWorkspace model, ModelWorkspaceEventArgs e)
        {
            tbx_workspace.Text = e.newRootpath;
            bt_OK.Enabled = true;
        } 
    }
}
