using System.Security.Cryptography;

namespace EncrpytDecrypt
{
    public class Model:IModel
    {
        #region Members
        private string workspacePath;
        private RSAParameters rsaKeys;
        public event ModelHandler<Model> worksapceChanged;
        public event ModelHandler<Model> enableButtons; 
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
            enableButtons += new ModelHandler<Model>(imo.enableOK);
        }
        public void attachMain(IModelObserverMain imo)
        {
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
                enableButtons.Invoke(this,null);
            }
            worksapceChanged.Invoke(this, new ModelEventArgs(workspacePath));
        }

        public string getWorkspacePath()
        {
            return workspacePath;
        }
    }
}
