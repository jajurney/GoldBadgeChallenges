using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
            ProgramUI menu = new ProgramUI();
            menu.Run();
        }
    }
}
