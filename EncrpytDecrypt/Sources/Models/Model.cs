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

        public void attachWorkspace(IModelObserverWorkspace imo)
        {
            worksapceChanged += new ModelHandler<Model>(imo.workspaceSet);
            enableWorkspaceButtons += new ModelHandler<Model>(imo.enableOK);
        }
        public void attachMain(IModelObserverMain imo)
        {
            rsaKeysCreated += new ModelHandler<Model>(imo.rsaKeysCreated);
            rsaKeysCreated += new ModelHandler<Model>(imo.logUpdated);
        }

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

        public void setRsaKeys(RSACryptoServiceProvider keys)
        {
            rsaKeys = keys;
            rsaKeysCreated.Invoke(this, new ModelEventArgs("RSA keys (public & private) created"));
        }

        public string getWorkspacePath()
        {
            return workspacePath;
        }

        public RSACryptoServiceProvider getRsaKeys()
        {
            return rsaKeys;
        }
    }
}
