using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Console
{
    class Program
    {
       static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
            ProgramUI menu = new ProgramUI();
            menu.Run();
           
        
           
        }
    }
}

