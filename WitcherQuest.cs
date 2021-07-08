using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone_bot
{
    public class WitcherQuest
    {
        public List<QuestInfo> quest { get; set; }
    }

    public class QuestInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string region { get; set; }
        public int level { get; set; }
        public string characters { get; set; }
        public string location { get; set; }
    }
}
