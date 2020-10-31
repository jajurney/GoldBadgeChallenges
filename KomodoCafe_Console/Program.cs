using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
     class Program
    {
        public static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
            ProgramUI menu= new ProgramUI();
            menu.MenuItems();
            
        





        }
    }
}
