using System;
using System.Security.Cryptography;

namespace EncrpytDecrypt
{
    /// <summary>
    /// Interface for the model
    /// </summary>
    public interface IModel
    {
        void attachWorkspace(IModelObserverWorkspace imo);
        void attachMain(IModelObserverMain imo);
        void setWorkspacePath(string path);
        string getWorkspacePath();
    }

    #region Observers
    /// <summary>
    /// Observer interface for all views
    /// </summary>
    public interface IModelObserver
    {        
    }
    /// <summary>
    /// Observer-interface of the workspace view
    /// </summary>
    public interface IModelObserverWorkspace:IModelObserver
    {
        void workspaceSet(IModel model, ModelEventArgs e);
        void enableOK(IModel model, ModelEventArgs e);
    }
    /// <summary>
    /// Observer-interface of the main view
    /// </summary>
    public interface IModelObserverMain : IModelObserver
    {
        void logUpdated(IModel model, ModelEventArgs e);
    }
    #endregion

    /// <summary>
    /// Eventhandler for the model
    /// </summary>
    /// <typeparam name="IModel"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ModelHandler<IModel>(IModel sender, ModelEventArgs e);
    /// <summary>
    /// Eventarguments of the model to be passed on to the view
    /// </summary>
    public class ModelEventArgs : EventArgs
    {
        public string value;
        public ModelEventArgs(string newValue)
        {
            value = newValue;
        }
    }
}
