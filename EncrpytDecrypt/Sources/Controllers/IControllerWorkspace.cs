using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrpytDecrypt
{
    public interface IControllerWorkspace
    {
        void chooseWorkspace(string path);
        void createNewWorkspace(string path);
    }
}
