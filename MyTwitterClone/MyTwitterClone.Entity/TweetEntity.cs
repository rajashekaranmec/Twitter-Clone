using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitterClone.Entity
{
    public class TweetEntity
    {
        public int tweet_id { get; set; }
        public string user_id { get; set; }
        public string message { get; set; }
        public System.DateTime created { get; set; }
    }
}
