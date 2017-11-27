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
        event ViewWorkspaceHandler<IViewWorkspace> rootpathChanged;
    }
    /// <summary>
    /// Eventhandler for the workspace view
    /// </summary>
    /// <typeparam name="IViewWorkspace"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ViewWorkspaceHandler<IViewWorkspace>(IViewWorkspace sender, ViewEventArgs e);
    #endregion

    #region Main view
    /// <summary>
    /// Interface for the main view
    /// </summary>
    public interface IViewMain:IView
    {
        void showMe();
        //event ViewMainHandler<IViewMain> rootpathChanged;
    }
    /// <summary>
    /// Eventhandler for the main view
    /// </summary>
    /// <typeparam name="IViewMain"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ViewMainHandler<IViewMain>(IViewMain sender, ViewEventArgs e);
    #endregion

    /// <summary>
    /// Eventarguments for the views
    /// </summary>
    public class ViewEventArgs : EventArgs
    {
        public string rootpath;

        public ViewEventArgs(string newPath)
        {
            rootpath = newPath;
        }
    }

    
}
