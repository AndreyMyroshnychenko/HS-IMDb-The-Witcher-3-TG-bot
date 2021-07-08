using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone_bot
{
    public class WitcherMonster
    {
        public List<Info> creatures { get; set; }
    }

    public class Info
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Class { get; set; }
        public string susceptibility { get; set; }
        public string immunity { get; set; }
        public string image { get; set; }
    }
}
