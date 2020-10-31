using Outings_Repsitory;
using Outings_Repsitory.Outings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Console
{
    class ProgramUI
    {
        private OutingContent_Repo _repo = new OutingContent_Repo();
        public void Run()
        {
            OutingsContent();
            Menu();
        
        }
        public void OutingsContent()
        {
            OutingContent golfOuting = new OutingContent(
                "Golf",
                30,
                (2020, 10, 17),
                100,
                3000);
            OutingContent bowlingOuting = new OutingContent(
                "Bowling",
                25,
                (),
                200,
                5000);
            OutingContent amusemnetOuting = new OutingContent(
               "Amusement Park",
               20,
               (),
               150,
               3000);
            OutingContent concertOuting = new OutingContent();
      

        }
        public  int Addition(int totalEvent)
        {
            int result = totalEvent + totalEvent + totalEvent + totalEvent;
            return result;
        }
    }
}
