using System;
using System.Windows.Forms;

namespace EncrpytDecrypt
{
    public partial class ViewWorkspace : Form,IViewWorkspace,IModelObserverWorkspace
    {
        #region Members
        private IController _controller;
        public event ViewWorkspaceHandler<IViewWorkspace> workspaceChanged;
        public event ViewWorkspaceHandler<IViewWorkspace> workspaceChoosed;
        public event ViewWorkspaceHandler<IViewWorkspace> newWorkspaceChoosed;
        #endregion

        public ViewWorkspace()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the controller for the view
        /// </summary>
        /// <param name="controller"></param>
        public void setController(IController controller)
        {
            _controller = controller;
        }

        #region Form-Events
        #region General events
        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ViewWorkspace_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.closeApplication();
        }
        private void bt_draftsman_Click(object sender, EventArgs e)
        {
            _controller.showAbout();
        }
        private void bt_OK_Click(object sender, EventArgs e)
        {
            this.Hide();
            _controller.showMain();
        }
        #endregion

        #region Workspace events
        private void bt_chooseWorkspace_Click(object sender, EventArgs e)
        {
            fbd_chooseWorkspace.ShowNewFolderButton = false;
            DialogResult result = fbd_chooseWorkspace.ShowDialog();
            if (result == DialogResult.OK)
            {
                workspaceChoosed.Invoke(this, new WorkspaceEventArgs(fbd_chooseWorkspace.SelectedPath));
            }
        }

        private void bt_new_Click(object sender, EventArgs e)
        {
            fbd_chooseWorkspace.ShowNewFolderButton = true;
            DialogResult result = fbd_chooseWorkspace.ShowDialog();
            if (result == DialogResult.OK)
            {
                newWorkspaceChoosed.Invoke(this, new WorkspaceEventArgs(fbd_chooseWorkspace.SelectedPath));
            }
        }

        private void tbx_workspace_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbx_workspace.Text))
            {
                workspaceChanged.Invoke(this, new WorkspaceEventArgs(tbx_workspace.Text));
            }
        }
        #endregion
        #endregion

        #region Observer
        /// <summary>
        /// Observer if a workspace is set
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void workspaceSet(IModel model, ModelEventArgs e)
        {
            tbx_workspace.Text = e.value;
        }

        /// <summary>
        /// Observer for enabling the OK-button
        /// </summary>
        /// <param name="model"></param>
        /// <param name="e"></param>
        public void enableOK(IModel model, ModelEventArgs e)
        {
            bt_OK.Enabled = true;
        }
        #endregion
    }
}
