using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Models
{
    public class Search
    {
        public Coins[] coins { get; set; }
    }

    public class Coins
    {
        public Items items { get; set; }
    }

    public class Items
    {
        public string id { get; set; }       
        public string name { get; set; }
        public string symbol { get; set; }
        public int market_cap_rank { get; set; }
        public string thumb { get; set; }       
        public string large { get; set; }        
    }
}
