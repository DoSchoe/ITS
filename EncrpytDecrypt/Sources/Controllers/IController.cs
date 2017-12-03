using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrpytDecrypt
{
    /// <summary>
    /// Interface for the controller
    /// </summary>
    public interface IController
    {
        //void chooseWorkspace(string path);
        //void createNewWorkspace(string path);
        void closeApplication();
        void showMain();
        void showAbout();
    }
}
