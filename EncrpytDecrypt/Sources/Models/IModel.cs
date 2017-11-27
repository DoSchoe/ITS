using System;

namespace EncrpytDecrypt
{
    /// <summary>
    /// Interface for the model
    /// </summary>
    public interface IModel
    {
        void attach(IModelObserver imo);
        void setRootpath(string path);
    }

    /// <summary>
    /// Obeserver for the model
    /// </summary>
    public interface IModelObserver
    {
        void rootpathSet(IModel model, ModelEventArgs e);
    }

    /// <summary>
    /// Eventhandler and Eventarguments for the model
    /// </summary>
    /// <typeparam name="IModel"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ModelHandler<IModel>(IModel sender, ModelEventArgs e);
    public class ModelEventArgs : EventArgs
    {
        public string newRootpath;
        public ModelEventArgs(string newPath)
        {
            newRootpath = newPath;
        }
    }
}
