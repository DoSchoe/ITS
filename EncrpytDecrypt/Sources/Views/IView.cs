using System;

namespace EncrpytDecrypt
{
    /// <summary>
    /// General interface fot the views
    /// </summary>
    public interface IView
    {
        void setController(IController controller);
    }

    #region Workspace view
    /// <summary>
    /// Inteface for the workspace view
    /// </summary>
    public interface IViewWorkspace:IView
    {
        event ViewWorkspaceHandler<IViewWorkspace> workspaceChanged;
        event ViewWorkspaceHandler<IViewWorkspace> workspaceChoosed;
        event ViewWorkspaceHandler<IViewWorkspace> newWorkspaceChoosed;
    }
    /// <summary>
    /// Eventhandler for the workspace view
    /// </summary>
    /// <typeparam name="IViewWorkspace"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ViewWorkspaceHandler<IViewWorkspace>(IViewWorkspace sender, WorkspaceEventArgs e);
    #endregion

    #region Main view
    /// <summary>
    /// Interface for the main view
    /// </summary>
    public interface IViewMain:IView
    {
        void showMe();
    }
    #endregion

    /// <summary>
    /// Eventarguments for the views
    /// </summary>
    public class WorkspaceEventArgs : EventArgs
    {
        public string workspacePath;

        public WorkspaceEventArgs(string newPath)
        {
            workspacePath = newPath;
        }
    }
}
