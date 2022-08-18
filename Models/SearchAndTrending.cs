using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Models
{
    public class SearchAndTrending
    {
        public IEnumerable<Trending> Trend { get; set; }
        public IEnumerable<Search> Search { get; set; }
    }
}
