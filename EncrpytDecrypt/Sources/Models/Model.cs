using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrpytDecrypt
{
    public class ModelWorkspace:IModel
    {
        #region Members
        private string rootpath;
        public event ModelHandler<ModelWorkspace> rootpathChanged;
        #endregion

        #region Singleton-Implementierung
        /// <summary>
        /// Declaration of the singelton
        /// </summary>
        private static ModelWorkspace _singleton = null;

        /// <summary>
        /// Method for creating or sending back the singelton instance of MainForm
        /// </summary>
        public static ModelWorkspace Instance
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new ModelWorkspace();
                }
                return _singleton;
            }
        }

        /// <summary>
        /// CTor
        /// </summary>
        private ModelWorkspace()
        {
            rootpath = "";
        }
        #endregion


        public void attach(IModelObserver imo)
        {
            rootpathChanged += new ModelHandler<ModelWorkspace>(imo.rootpathSet);
        }

        public void setRootpath(string path)
        {
            rootpath = path;
            rootpathChanged.Invoke(this, new ModelEventArgs(rootpath));
        }
    }
}
