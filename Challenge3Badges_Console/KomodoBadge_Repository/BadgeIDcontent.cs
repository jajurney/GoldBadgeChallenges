using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repository
{
    public interface  BadgeIDcontent
    {
        public int BadgeID { get; set; }

        public List<Door> AccessDoor { get; set; }
        public BadgeIDcontent() { }
        public BadgeIDcontent(int badgeID, List<string> accessDoor)
        {
            BadgeID = badgeID;

            AccessDoor = accessDoor;
        }

    public List<string> AccessDoor = new List<string>()
    {

    }
    }
    
    
}
