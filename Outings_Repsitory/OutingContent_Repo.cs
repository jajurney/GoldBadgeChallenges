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
        public OutingContent GetOutingByDate(DateTime dateOfEvent)
        {
            foreach (OutingContent outingContent in _contentList)
            {
                if (outingContent.EventDate.ToString() == dateOfEvent.ToString())
                {
                    return outingContent;
                }

            }
            return null;
        }
        public bool UpdateExistingOutingContent(DateTime originalDate , OutingContent newContent)
        {
            OutingContent oldContent = GetOutingByDate(originalDate);
            if (oldContent != null)
            {
                oldContent.Event = newContent.Event;
                oldContent.PeopleAttended = newContent.PeopleAttended;
                oldContent.EventDate = newContent.EventDate;
                oldContent.TotalCostPerson = newContent.TotalCostPerson;
               // oldContent.TotalCostEvent = newContent.TotalCostEvent;
                return true;
            }
            else
            {
                return false;
            }


        }
       
    }
}
