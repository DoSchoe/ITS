using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EncrpytDecrypt
{
    /// <summary>
    /// Controller for the EncryptDecrypt project
    /// </summary>
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

            //Main eventhandler
            _viewMain.createRsaKeys += new ViewMainHandler<IViewMain>(this.createRsaKeys);
            _viewMain.exportRsaKey += new ViewMainHandler<IViewMain>(this.exportRsaKey);
            _viewMain.encryptFile += new FileHandler<IViewMain>(this.encryptFile);
            _viewMain.decryptFile += new FileHandler<IViewMain>(this.decryptFile);
            _viewMain.deleteAllFiles += new ViewMainHandler<IViewMain>(this.deleteAllFiles);

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

        /// <summary>
        /// Triggered method if the 'exportRsaKey'-event is fired
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportRsaKey(IViewMain sender, EventArgs e)
        {
            if (true == exportPublicRsaKey())
            {
                _viewMain.updateLogFile("Public RSA key exported.");
            }
        }

        /// <summary>
        /// Triggered method if the 'encryptFile'-event is fired
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">File path of the plain file.</param>
        private void encryptFile(IViewMain sender, FileEventArgs e)
        {
            if (true == encryption(e.filePath))
            {
                string filename = new FileInfo(e.filePath).Name;
                _viewMain.updateLogFile("File (" + filename + ") encrypted!");
            }
        }

        /// <summary>
        /// Triggered method if the 'decryptFile'-event is fired
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">File path of the encrypted file.</param>
        private void decryptFile(IViewMain sender, FileEventArgs e)
        {
            if (true == decryption(e.filePath))
            {
                string filename = new FileInfo(e.filePath).Name;
                _viewMain.updateLogFile("File (" + filename + ") decrypted");   
            }
        }


        /// <summary>
        /// Triggered method if the 'clearWorkspace'-event is fired
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAllFiles(IViewMain sender, EventArgs e)
        {
            if (true == deleteFiles())
            {
                _viewMain.updateLogFile("Workspace cleared!");
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

        /// <summary>
        /// Checks if a file with the public RSA-key exists and loads it (isn't needed!)
        /// </summary>
        private void checkPublicKeyFile()
        {
            string keypath = _model.getWorkspacePath() + "\\" + templateFolders[3];
            DirectoryInfo key = new DirectoryInfo(keypath);
            FileInfo[] rsaPublicKeyFiles = key.GetFiles("rsaPublicKey*.txt");
            int keyCount = rsaPublicKeyFiles.Length;
            if (1 <= keyCount)
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                StreamReader sr = new StreamReader(rsaPublicKeyFiles.Last().FullName);
                string keytxt = sr.ReadToEnd();
                rsa.FromXmlString(keytxt);
                rsa.PersistKeyInCsp = false;
                sr.Close();
                _model.loadPublicRsaKey(rsa);
            }
            else
            {
                _viewMain.updateLogFile("No Public key loaded");
            }
        }
        #endregion

        #region Main methods
        /// <summary>
        /// Create asymmetric keys
        /// </summary>
        private void createRsaKeys()
        {
            RSACryptoServiceProvider rsa;
            rsa = new RSACryptoServiceProvider();
            rsa.PersistKeyInCsp = false;
            _model.setRsaKeys(rsa);
        }

        /// <summary>
        /// Creates symmetric key and intial vector
        /// </summary>
        /// <returns>Returns the created RijndaelManged class.</returns>
        private RijndaelManaged createSymKey()
        {
            RijndaelManaged symKey = new RijndaelManaged();
            symKey.KeySize = 256;
            symKey.BlockSize = 256;
            symKey.Mode = CipherMode.CBC;

            return symKey;
        }

        /// <summary>
        /// Copies a selected file to the '00_Documents' folder if it isn't its directory
        /// </summary>
        /// <param name="filePath">File path of the original file.</param>
        /// <returns>Fileinfo of the copied file.</returns>
        private FileInfo copyFile(string filePath)
        {
            FileInfo actualFile = new FileInfo(filePath);
            string targetFilePath = _model.getWorkspacePath() + "\\" + templateFolders[0];

            if (actualFile.DirectoryName != targetFilePath)
            {
                string targetFilename = targetFilePath + "\\" + actualFile.Name;
                File.Copy(filePath, targetFilename, true);
                return new FileInfo(targetFilename);
            }
            else
            {
                return new FileInfo(filePath);
            }
        }

        /// <summary>
        /// Creates the file path for the encrypted file
        /// </summary>
        /// <param name="originalFile">Fileinfo of the original file.</param>
        /// <returns>File path and name for the encrypted file.</returns>
        private string createEncryptedFilenname(FileInfo originalFile)
        {
            string encryptedFilename = _model.getWorkspacePath() + "\\" + templateFolders[1] + "\\" +
                                       originalFile.Name + ".enc";
            return encryptedFilename;
        }

        /// <summary>
        /// Creates the file path for the key file
        /// </summary>
        /// <param name="originalFile">Fileinfo of the original file.</param>
        /// <returns>File path and name for the key file.</returns>
        private string createKeyFilename(FileInfo originalFile)
        {
            string keyFilename = _model.getWorkspacePath() + "\\" + templateFolders[3] + "\\" +
                                 originalFile.Name + ".mykey";
            return keyFilename;
        }

        /// <summary>
        /// Creates the file path for the decrypted file
        /// </summary>
        /// <param name="encryptedFile">FileInfo of the encrypted file.</param>
        /// <returns>File path and name for the decrypted file.</returns>
        private string createDecryptedFilename(FileInfo encryptedFile)
        {
            string decryptedFilename = _model.getWorkspacePath() + "\\" + templateFolders[2] + "\\" +
                                       encryptedFile.Name.Substring(0, encryptedFile.Name.Length - 4);
            return decryptedFilename;
        }

        /// <summary>
        /// Searches the file with the symetric keys for the encrpyted file
        /// </summary>
        /// <param name="encryptedFile">FileInfo of the encrypted file.</param>
        /// <returns>FileInfo of the key file.</returns>
        private FileInfo searchKeyFile(FileInfo encryptedFile)
        {
            string keyFullFilename = _model.getWorkspacePath() + "\\" + templateFolders[3] + "\\" +
                                 encryptedFile.Name.Substring(0, encryptedFile.Name.Length - 4) + ".mykey";
            FileInfo keyFile = new FileInfo(keyFullFilename);
            if (keyFile.Exists)
            {
                return keyFile;
            }
            else
            {
                throw new Exception("No Key-file found for the choosen encrypted file!");
            }
        }

        /// <summary>
        /// Exports the public RSA-key
        /// </summary>
        /// <returns>TRUE if the export was succesful.</returns>
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
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// Decrypts a file
        /// </summary>
        /// <param name="filePath">File path of the encrypted file.</param>
        /// <returns>TRUE if the decryption was succesful.</returns>
        private bool decryption(string filePath)
        {
            try
            {
                FileInfo encryptedFile = new FileInfo(filePath);
                string decryptedFilename = createDecryptedFilename(encryptedFile);
                FileInfo keyFile = searchKeyFile(encryptedFile);

                //Reads the symetric key and IV
                StreamReader readKeyFile = new StreamReader(keyFile.FullName);
                string symIVString = readKeyFile.ReadLine();
                string symKeyEncString = readKeyFile.ReadLine();
                readKeyFile.Close();
                byte[] symIV = Convert.FromBase64String(symIVString);
                byte[] symKeyEnc = Convert.FromBase64String(symKeyEncString);
                byte[] symKey = _model.getRsaKeys().Decrypt(symKeyEnc, false);

                //Creates the decryptor
                RijndaelManaged aes = createSymKey();
                ICryptoTransform decryptor = aes.CreateDecryptor(symKey, symIV);

                //Reads the encrypted file
                FileStream fsEncryptedFile = new FileStream(encryptedFile.FullName, FileMode.Open);
                FileStream fsDecryption = new FileStream(decryptedFilename,FileMode.Create);
                CryptoStream csDecryption = new CryptoStream(fsDecryption,decryptor,CryptoStreamMode.Write);
                int readBytes = 0;
                int blockSizeInBytes = aes.BlockSize / 8;
                byte[] readData = new byte[blockSizeInBytes];
                do
                {
                    readBytes = fsEncryptedFile.Read(readData, 0, blockSizeInBytes);
                    csDecryption.Write(readData, 0, readBytes);
                }
                while (readBytes > 0);

                csDecryption.FlushFinalBlock();
                fsEncryptedFile.Close();
                fsDecryption.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// Encrypts a file
        /// </summary>
        /// <param name="filePath">File path of the original file.</param>
        /// <returns>TRUE if the encryption was succesful.</returns>
        private bool encryption(string filePath)
        {
            try
            {
                //Copies the plain file to the '00_Documents' folder 
                FileInfo plainFile = copyFile(filePath);

                //Load the asymmetric keys and generate the symmetric key and IV
                RSACryptoServiceProvider asymKeys = _model.getRsaKeys();
                RijndaelManaged aes = createSymKey();

                //Temporal members
                byte[] symKey = aes.Key;
                byte[] symKeyEnc = asymKeys.Encrypt(symKey, false);
                byte[] symIV = aes.IV;
                string symKeyEncString = Convert.ToBase64String(symKeyEnc);
                string symIVString = Convert.ToBase64String(symIV);

                //Generate file names
                string encryptedFilename = createEncryptedFilenname(plainFile);
                string keyFilename = createKeyFilename(plainFile);

                StreamWriter keyFile = new StreamWriter(keyFilename, false);
                keyFile.WriteLine(symIVString);
                keyFile.WriteLine(symKeyEncString);
                keyFile.Close();

                //Write-Filestream for the encrypted file
                FileStream fsEncryption = new FileStream(encryptedFilename, FileMode.Create);

                //Cryptostream for encryption
                ICryptoTransform encryptor = aes.CreateEncryptor();
                CryptoStream csEncryption = new CryptoStream(fsEncryption, encryptor, CryptoStreamMode.Write);

                //Read-Filestream of the plain file
                FileStream fsPlainFile = new FileStream(plainFile.FullName, FileMode.Open);
                int readBytes = 0;
                int blockSizeInBytes = aes.BlockSize / 8;
                byte[] readData = new byte[blockSizeInBytes];
                do
                {
                    readBytes = fsPlainFile.Read(readData, 0, blockSizeInBytes);
                    csEncryption.Write(readData, 0, readBytes);
                }
                while (readBytes > 0);
                csEncryption.FlushFinalBlock();

                fsPlainFile.Close();
                csEncryption.Close();
                fsEncryption.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// Delets all files in the workspace
        /// </summary>
        /// <returns>TRUE if the deletion was succesful.</returns>
        private bool deleteFiles()
        {
            try
            {
                DirectoryInfo workspace = new DirectoryInfo(_model.getWorkspacePath());
                foreach (DirectoryInfo dir in workspace.GetDirectories())
                {
                    dir.Delete(true);
                }
                foreach (FileInfo file in workspace.GetFiles())
                {
                    file.Delete();
                }
                createWorkspace(workspace);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK);
                return false;
            }
            
        }

        #endregion
        #endregion
    }
}