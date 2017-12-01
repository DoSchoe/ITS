using System.Security.Cryptography;

namespace EncrpytDecrypt
{
    public class Model:IModel
    {
        #region Members
        private string workspacePath;
        private RSACryptoServiceProvider rsaKeys;
        public event ModelHandler<Model> worksapceChanged;
        public event ModelHandler<Model> enableWorkspaceButtons;
        public event ModelHandler<Model> rsaKeysCreated;
        public event ModelHandler<Model> publicRsaKeyLoaded; 
        #endregion

        #region Singleton-Implementierung
        /// <summary>
        /// Declaration of the singelton
        /// </summary>
        private static Model _singleton = null;

        /// <summary>
        /// Method for creating or sending back the singelton instance of MainForm
        /// </summary>
        public static Model Instance
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new Model();
                }
                return _singleton;
            }
        }

        /// <summary>
        /// CTor
        /// </summary>
        private Model()
        {
            workspacePath = "";
        }
        #endregion

        #region Observer
        /// <summary>
        /// Attach observer for the workspace view
        /// </summary>
        /// <param name="imo">Selected view</param>
        public void attachWorkspace(IModelObserverWorkspace imo)
        {
            worksapceChanged += new ModelHandler<Model>(imo.workspaceSet);
            enableWorkspaceButtons += new ModelHandler<Model>(imo.enableOK);
        }
        /// <summary>
        /// Attach observer for the main view
        /// </summary>
        /// <param name="imo">Selected view</param>
        public void attachMain(IModelObserverMain imo)
        {
            rsaKeysCreated += new ModelHandler<Model>(imo.rsaKeysCreated);
            rsaKeysCreated += new ModelHandler<Model>(imo.logUpdated);
            publicRsaKeyLoaded += new ModelHandler<Model>(imo.logUpdated);
            publicRsaKeyLoaded += new ModelHandler<Model>(imo.publicRsaKeyLoaded);
        }
        #endregion

        #region Controller methods
        /// <summary>
        /// Sets the workspace path in the model
        /// </summary>
        /// <param name="path"></param>
        public void setWorkspacePath(string path)
        {
            if (path == null)
            {
                workspacePath = "";
            }
            else
            {
                workspacePath = path;
                enableWorkspaceButtons.Invoke(this,null);
            }
            worksapceChanged.Invoke(this, new ModelEventArgs(workspacePath));
        }

        /// <summary>
        /// Sets the RSA-keys(public & private) in the model
        /// </summary>
        /// <param name="keys"></param>
        public void setRsaKeys(RSACryptoServiceProvider keys)
        {
            rsaKeys = keys;
            rsaKeysCreated.Invoke(this, new ModelEventArgs("RSA-keys (public & private) created"));
        }

        /// <summary>
        /// Sets the loaded public RSA-key
        /// </summary>
        /// <param name="key"></param>
        public void loadPublicRsaKey(RSACryptoServiceProvider key)
        {
            rsaKeys = key;
            publicRsaKeyLoaded.Invoke(this, new ModelEventArgs("Public RSA-key loaded"));
        }

        /// <summary>
        /// Returns the current workspace path
        /// </summary>
        /// <returns></returns>
        public string getWorkspacePath()
        {
            return workspacePath;
        }

        /// <summary>
        /// Returns the RSA-keys
        /// </summary>
        /// <returns></returns>
        public RSACryptoServiceProvider getRsaKeys()
        {
            return rsaKeys;
        }
        #endregion
    }
}
