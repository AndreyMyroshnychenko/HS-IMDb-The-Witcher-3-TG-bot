using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Hearthstone_bot
{
    public class Character
    {
        public List<WitcherCharacter> character { get; set; }
    }
    public class WitcherCharacter
    {
        
        public int id { get; set; }

        public string name { get; set; }

        public string gender { get; set; }

        public string race { get; set; }

        public string profession { get; set; }

        public string image { get; set; }
    }

}
