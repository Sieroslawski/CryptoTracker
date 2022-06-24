using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.ViewModels
{
    public class CryptoUserTransactionVM
    {
        [DisplayName("User ID")]
        public int userID { get; set; }
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [DisplayName("User Name")]
        public string userName { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Transaction ID")]
        public int transactionID { get; set; }
        [DisplayName("Coin Image")]
        public string coinImage { get; set; }
        [DisplayName("Ticket")]
        public string coinTicker { get; set; }
        [DisplayName("Coin Amount")]

        public decimal coinAmount { get; set; }
        [DisplayName("Coin Value")]

        public decimal coinValue { get; set; }
        [DisplayName("Purchase Price")]
        public decimal purchasePrice { get; set; }
        [DisplayName("Purchase Time")]
        public DateTime purchaseTime { get; set; }
    }
}
