using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace EncrpytDecrypt
{
    public class ControllerWorkspace:IControllerWorkspace
    {
        #region Members
        private static readonly string[] templateFolders = new string[4]{"00_Documents", "01_Encrypt","02_Decrypt","03_Keys"};
        private IViewWorkspace _view;
        private IModelWorkspace _model;
        #endregion

        /// <summary>
        /// CTor
        /// </summary>
        /// <param name="view"></param>
        /// <param name="model"></param>
        public ControllerWorkspace(IViewWorkspace view, IModelWorkspace model)
        {
            _view = view;
            _model = model;
            _view.setController(this);
            _model.attach((IModelWorkspaceObserver)_view);
            _view.rootpathChanged += new ViewWorkspaceHandler<IViewWorkspace>(this.rootpathChanged);
        }

        private void rootpathChanged(IViewWorkspace sender, ViewEventArgs e)
        {
            chooseWorkspace(e.rootpath);
        }

        public void chooseWorkspace(string path)
        {
            DirectoryInfo rootFolder = new DirectoryInfo(path);
            int isChecked = checkWorkspace(rootFolder);
            if (0 == isChecked)
            {
                _model.setRootpath(path);
            }
            else if(1 == isChecked)
            {
                DialogResult newWorkspace = MessageBox.Show("Ordner ist leer.\nWollen Sie die notwendige Ordnerstruktur anlegen?", "Neuen Workspace anlegen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == newWorkspace)
                {
                    createWorkspace(rootFolder);
                    _model.setRootpath(path);
                }
            }
            else
            {
                MessageBox.Show("Falsche Ordnerstruktur!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void createNewWorkspace(string path)
        {
            DirectoryInfo rootFolder = new DirectoryInfo(path);
            int isChecked = checkWorkspace(rootFolder);
            if (1 == isChecked)
            {
                createWorkspace(rootFolder);
                _model.setRootpath(path);
            }
            else if (0 == isChecked)
            {
                DialogResult existingWorkspace =
                    MessageBox.Show(
                        "Ordner enthält bereits die entsprechenden Ordner.\nWollen Sie den Workspace verwenden?",
                        "Workspace verwenden?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == existingWorkspace)
                {
                    _model.setRootpath(path);
                }
            }
            else
            {
                MessageBox.Show("Falsche Ordnerstruktur!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Private methods
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
    }
}
