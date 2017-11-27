using System;
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
            ViewWorkspace _viewWorkspace = new ViewWorkspace();
            ViewMain _viewMain = new ViewMain();
            IModel _modelWorkspace = ModelWorkspace.Instance;
            IController _controllerWorkspace = new ControllerWorkspace(_viewWorkspace, _viewMain, _modelWorkspace);
            _viewWorkspace.Show();
            Application.Run();
        }
    }
}
