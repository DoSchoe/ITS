using System;

namespace EncrpytDecrypt
{
    /// <summary>
    /// Inteface for the view of the workspace
    /// </summary>
    public interface IViewWorkspace
    {
        void setController(IControllerWorkspace controller);
        event ViewWorkspaceHandler<IViewWorkspace> rootpathChanged;
    }

    /// <summary>
    /// Eventhandler and Eventarguments for the view of the workspace
    /// </summary>
    /// <typeparam name="IViewWorkspace"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ViewWorkspaceHandler<IViewWorkspace>(IViewWorkspace sender, ViewEventArgs e);
    public class ViewEventArgs : EventArgs
    {
        public string rootpath;

        public ViewEventArgs(string newPath)
        {
            rootpath = newPath;
        }
    }
}
