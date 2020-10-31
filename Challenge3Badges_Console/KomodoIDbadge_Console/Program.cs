using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIDbadge_Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();

            List<string> accessDoor = new List<string>();
            accessDoor.ToList();
            Dictionary<int, List<string>> BadgeID = new Dictionary<int, List<string>>();
        }
    }
}
