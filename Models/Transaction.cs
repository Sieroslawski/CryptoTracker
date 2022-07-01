using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Models
{
    public class Transaction
    {
        [Key, Column(Order = 0)]
        public int transactionID { get; set; }
        [DisplayName("Coin ID")]
        public int coinID { get; set; }
        [DisplayName("Coin Image")]
        public string coinImage { get; set; }
        [DisplayName("Coin Ticker")]
        public string coinTicker { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [DisplayName("Coin Amount")]
        public decimal coinAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [DisplayName("Coin Value")]
        public decimal coinValue { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [DisplayName("Purchase Price")]
        public decimal purchasePrice { get; set; }
        [DisplayName("Purchase Time")]
        public DateTime purchaseTime { get; set; }
        public virtual ICollection<CryptoUserTransaction> UserTransactions { get; set; }
    }
}
