using System;

namespace EncrpytDecrypt
{
    /// <summary>
    /// Interface for the model of the workspace
    /// </summary>
    public interface IModelWorkspace
    {
        void attach(IModelWorkspaceObserver imo);
        void setRootpath(string path);
    }

    /// <summary>
    /// Obeserver for the model of the workspace
    /// </summary>
    public interface IModelWorkspaceObserver
    {
        void rootpathSet(IModelWorkspace model, ModelWorkspaceEventArgs e);
    }

    /// <summary>
    /// Eventhandler and Eventarguments for the model of the workspace.
    /// </summary>
    /// <typeparam name="IModelWorkspace"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ModelHandler<IModelWorkspace>(IModelWorkspace sender, ModelWorkspaceEventArgs e);
    public class ModelWorkspaceEventArgs : EventArgs
    {
        public string newRootpath;
        public ModelWorkspaceEventArgs(string newPath)
        {
            newRootpath = newPath;
        }
    }
}
