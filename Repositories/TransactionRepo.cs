using CryptoTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Repositories
{
    public class TransactionRepo
    {
        public string coinId = "";
        public List<Trending> GetTrend()
        {
            List<Trending> trending = new List<Trending>();
            return trending;
        }
           
        
        public void getID(string id)
        {
            coinId = id;
        }
    }
}

