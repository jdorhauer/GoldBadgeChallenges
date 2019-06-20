using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> _badge = new Dictionary<int, List<string>>();

        public Dictionary<int, List<string>> GetListOfBadges()
        {
            return _badge;
        }

        public List<string> GetListOfDoors()
        {
            foreach (KeyValuePair<int, List<string>> pair in _badge)
            {
                return pair.Value;
            }
            return null;
        }

        public void AddBadge(Badge badge)
        {
            _badge.Add(badge.BadgeID, badge.AccessibleDoors);
        }

        public void RemoveAllAccess(int badgeID)
        {
            _badge.Remove(badgeID);
        }

        public void GiveSingleAccess(int badgeID, string newDoor)
        {
            _badge[badgeID].Add(newDoor);
        }

        public void RemoveSingleAccess(int badgeID, string door)
        {
            _badge[badgeID].Remove(door);
        }
    }
}
