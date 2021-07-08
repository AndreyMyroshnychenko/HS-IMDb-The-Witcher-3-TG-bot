using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone_bot
{
    public class IMDbModelForFilms
    {
        public string query { get; set; }
        public List<Results> results { get; set; }
    }

    public class Results
    {
        public Image image { get; set; }
        public int runningTimeInMinutes { get; set; }
        public string title { get; set; }
        public string titleType { get; set; }
        public int year { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
    }
}
