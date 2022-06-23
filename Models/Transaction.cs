using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Models
{
    public class Transaction
    {
        [Key]
        public int transactionID { get; set; }
        public string coinImage { get; set; }
        public string coinTicker { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal coinAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal coinValue { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal purchasePrice { get; set; }
        public DateTime purchaseTime { get; set; }
        public virtual ICollection<CryptoUserTransaction> UserTransactions { get; set; }
    }
}
