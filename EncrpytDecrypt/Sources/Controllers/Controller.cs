using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace EncrpytDecrypt
{
    public class ControllerWorkspace:IController
    {
        #region Members
        private static readonly string[] templateFolders = new string[4]{"00_Documents", "01_Encrypt","02_Decrypt","03_Keys"};
        private IViewWorkspace _viewWorkspace;
        private IViewMain _viewMain;
        private IModel _model;
        #endregion

        /// <summary>
        /// CTor
        /// </summary>
        /// <param name="viewWorkspace"></param>
        /// <param name="viewMain"></param>
        /// <param name="model"></param>
        public ControllerWorkspace(IViewWorkspace viewWorkspace, IViewMain viewMain, IModel model)
        {
            _viewWorkspace = viewWorkspace;
            _viewMain = viewMain;
            _model = model;
            _viewWorkspace.setController(this);
            _viewMain.setController(this);
            _model.attachWorkspace((IModelObserverWorkspace)_viewWorkspace);
            _model.attachMain((IModelObserverMain)_viewMain);

            //Workspace eventhandler
            _viewWorkspace.workspaceChanged += new ViewWorkspaceHandler<IViewWorkspace>(this.workspaceChanged);
            _viewWorkspace.workspaceChoosed += new ViewWorkspaceHandler<IViewWorkspace>(this.workspaceChoosed);
            _viewWorkspace.newWorkspaceChoosed += new ViewWorkspaceHandler<IViewWorkspace>(this.newWorkspaceChoosed);

            //Mein eventhandler
            _viewMain.createRsaKeys += new ViewMainHandler<IViewMain>(this.createRsaKeys);
            _viewMain.exportRsaKey += new ViewMainHandler<IViewMain>(this.exportRsaKey);

        }

        #region Event methods
        #region Workspace
        /// <summary>
        /// Triggered method if the 'workspaceChanged'-event is fired.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workspaceChanged(IViewWorkspace sender, WorkspaceEventArgs e)
        {
            chooseWorkspace(e.workspacePath);
        }
        /// <summary>
        /// Triggered method if the 'workspaceChoosed'-event is fired.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workspaceChoosed(IViewWorkspace sender, WorkspaceEventArgs e)
        {
            chooseWorkspace(e.workspacePath);
        }
        /// <summary>
        /// Triggered method if the 'newWorkspaceChoosed'-event is fired.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newWorkspaceChoosed(IViewWorkspace sender, WorkspaceEventArgs e)
        {
            createNewWorkspace(e.workspacePath);
        }
        #endregion
        #region Main
        /// <summary>
        /// Triggered method if the 'createRsaKeys'-event is fired.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createRsaKeys(IViewMain sender, EventArgs e)
        {
            createRsaKeys();
        }

        private void exportRsaKey(IViewMain sender, EventArgs e)
        {
            if (true == exportPublicRsaKey())
            {
                _viewMain.updateLogFile("Public RSA key exportet.");
            }
        }
        #endregion
        #endregion

        #region General methods
        /// <summary>
        /// Shows the main view.
        /// </summary>
        public void showMain()
        {
            checkPublicKeyFile();
            _viewMain.showMe();
        }
        /// <summary>
        /// Shows the 'About'-dialog
        /// </summary>
        public void showAbout()
        {
            new DialogAbout().ShowDialog();
        }
        /// <summary>
        /// Close the application
        /// </summary>
        public void closeApplication()
        {
            Application.Exit();
        }
        #endregion

        private void checkPublicKeyFile()
        {
            string keypath = _model.getWorkspacePath() + "\\" + templateFolders[3];
            DirectoryInfo key = new DirectoryInfo(keypath);
            FileInfo[] rsaPublicKeyFiles = key.GetFiles("rsaPublicKey*.txt");
            int keyCount = rsaPublicKeyFiles.Length;
            if (1 <= keyCount)
            {
                //CspParameters cspp = new CspParameters();
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                StreamReader sr = new StreamReader(rsaPublicKeyFiles[0].FullName);
                //cspp.KeyContainerName = rsaPublicKeyFiles[0].Name.Split('.')[0];
                //rsa = new RSACryptoServiceProvider(cspp);
                string keytxt = sr.ReadToEnd();
                rsa.FromXmlString(keytxt);
                //rsa.PersistKeyInCsp = true;
                rsa.PersistKeyInCsp = false;
                sr.Close();

                //_model.setRSAkeys(rsa.ExportParameters(false), "Public RSA-key loaded");
            }
            else
            {
                //_viewMain.updateLog("No Public key loaded");
            }
        }

        #region Private methods
        #region Workspace methods
        /// <summary>
        /// Checks whether a directory can be created in the specified path.
        /// </summary>
        /// <param name="path"></param>
        private void createNewWorkspace(string path)
        {
            DirectoryInfo rootFolder = new DirectoryInfo(path);
            int isChecked = checkWorkspace(rootFolder);
            if (1 == isChecked)
            {
                createWorkspace(rootFolder);
                _model.setWorkspacePath(path);
            }
            else if (0 == isChecked)
            {
                DialogResult existingWorkspace =
                    MessageBox.Show(
                        "Ordner enthält bereits die entsprechenden Ordner.\nWollen Sie den Workspace verwenden?",
                        "Workspace verwenden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == existingWorkspace)
                {
                    _model.setWorkspacePath(path);
                }
            }
            else
            {
                MessageBox.Show("Falsche Ordnerstruktur!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _model.setWorkspacePath(null);
            }
        }
        /// <summary>
        /// Checks whether the specified path is a suitable directory.
        /// </summary>
        /// <param name="path"></param>
        private void chooseWorkspace(string path)
        {
            DirectoryInfo rootFolder = new DirectoryInfo(path);
            int isChecked = checkWorkspace(rootFolder);
            if (0 == isChecked)
            {
                _model.setWorkspacePath(path);
            }
            else if (1 == isChecked)
            {
                DialogResult newWorkspace = MessageBox.Show("Ordner ist leer.\nWollen Sie die notwendige Ordnerstruktur anlegen?", "Neuen Workspace anlegen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == newWorkspace)
                {
                    createWorkspace(rootFolder);
                    _model.setWorkspacePath(path);
                }
            }
            else
            {
                MessageBox.Show("Falsche Ordnerstruktur!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _model.setWorkspacePath(null);
            }
        }
        /// <summary>
        /// Checks the subfolders of the root folder
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int checkWorkspace(DirectoryInfo root)
        {
            int response = 0;
            if (root.Exists)
            {
                if (root.GetDirectories().Length == templateFolders.Length)
                {
                    foreach (var folder in root.GetDirectories())
                    {
                        if (templateFolders.Contains(folder.Name))
                        {
                        }
                        else
                        {
                            response = 2;
                        }
                    }
                }
                else if (0 == root.GetDirectories().Length)
                {
                    response = 1;
                }
                else
                {
                    response = 2;
                }
            }
            else
            {
                response = 2;
            }
            return response;
        }

        /// <summary>
        /// Creates the needed folders
        /// </summary>
        /// <param name="root"></param>
        private void createWorkspace(DirectoryInfo root)
        {
            foreach (string foldername in templateFolders)
            {
                string newFolder = root.FullName + "\\" + foldername;
                Directory.CreateDirectory(newFolder);
            }            
        }
        #endregion

        #region Main methods
        private void createRsaKeys()
        {
            RSACryptoServiceProvider rsa;
            rsa = new RSACryptoServiceProvider();
            rsa.PersistKeyInCsp = false;
            _model.setRsaKeys(rsa);
        }

        private bool exportPublicRsaKey()
        {
            try
            {
                string keypath = _model.getWorkspacePath() + "\\" + templateFolders[3];
                DirectoryInfo key = new DirectoryInfo(keypath);
                int savedPublicKeys = key.GetFiles("rsaPublicKey*.txt").Length;
                string fullFileName = keypath + "\\" + "rsaPublicKey" + savedPublicKeys + ".txt";
                RSACryptoServiceProvider rsa = _model.getRsaKeys();
                StreamWriter sw = new StreamWriter(fullFileName, false);
                sw.Write(rsa.ToXmlString(false));
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error", e.Message, MessageBoxButtons.AbortRetryIgnore);
                return false;
            }
        }
        #endregion
        #endregion
    }
}
