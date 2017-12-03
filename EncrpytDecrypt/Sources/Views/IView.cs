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
        void updateLogFile(string msg);
        event ViewMainHandler<IViewMain> createRsaKeys;
        event ViewMainHandler<IViewMain> exportRsaKey;
        event FileHandler<IViewMain> encryptFile;
        event FileHandler<IViewMain> decryptFile; 
        event ViewMainHandler<IViewMain> deleteAllFiles;
    }
    public delegate void ViewMainHandler<IViewMain>(IViewMain sender, EventArgs e);
    public delegate void FileHandler<IViewMain>(IViewMain sender, FileEventArgs e);
    #endregion

    /// <summary>
    /// Eventargument for handling the workspace
    /// </summary>
    public class WorkspaceEventArgs : EventArgs
    {
        public string workspacePath;
        public WorkspaceEventArgs(string newPath)
        {
            workspacePath = newPath;
        }
    }

    /// <summary>
    /// Eventargument for handling a file
    /// </summary>
    public class FileEventArgs : EventArgs
    {
        public string filePath;
        public FileEventArgs(string newPath)
        {
            filePath = newPath;
        }
    }
}
