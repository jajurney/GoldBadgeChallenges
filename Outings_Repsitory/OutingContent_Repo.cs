using Outings_Repsitory.Outings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Repsitory
{
    public class OutingContent_Repo
    {
        private List<OutingContent> _contentList = new List<OutingContent>();

        public bool AddOutingToList(OutingContent outingContent)
        {
            int startCount = _contentList.Count;
            _contentList.Add(outingContent);
            bool wasAdded = (_contentList.Count > startCount) ? true : false;
            return wasAdded;
        }
        public List<OutingContent> GetOutingContents()
        {
            return _contentList;
        }
        public OutingContent GetOutingByType(string eventType)
        {
            foreach (OutingContent outingContent in _contentList)
            {
                if (outingContent.EventType.ToLower() == eventType.ToLower())
                {
                    return outingContent;
                }

            }
            return null;
        }
        public bool UpdateExistingOutingContent(string originalTitle, OutingContent newContent)
        {
            OutingContent oldContent = GetOutingByType(originalTitle);
            if (oldContent != null)
            {
                oldContent.EventType = newContent.EventType;
                oldContent.PeopleAttended = newContent.PeopleAttended;
                oldContent.EventDate = newContent.EventDate;
                oldContent.TotalCostPerson = newContent.TotalCostPerson;
                oldContent.TotalCostEvent = newContent.TotalCostEvent;
                return true;
            }
            else
            {
                return false;
            }


        }
       
    }
}
