using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Models
{
    public class CryptoUserTransaction
    {
        [Key, Column(Order = 0)]
        public int userID { get; set; }
        [Key, Column(Order = 1)]
        public int transactionID { get; set; }
        public virtual CryptoUser CryptoUser { get; set; }
        public virtual Transaction Transactions { get; set; }
    }
}
