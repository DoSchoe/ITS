using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncrpytDecrypt
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Workspace _viewWorkspace = new Workspace();
            IModelWorkspace _modelWorkspace = ModelWorkspace.Instance;
            IControllerWorkspace _controllerWorkspace = new ControllerWorkspace(_viewWorkspace, _modelWorkspace);
            Application.Run(_viewWorkspace);
        }
    }
}
