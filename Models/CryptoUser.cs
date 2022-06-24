using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Models
{
    public class CryptoUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }       
        public string firstName { get; set; }       
        public string lastName { get; set; }       
        public string userName { get; set; }
        public string email { get; set; }
        public virtual ICollection<CryptoUserTransaction> UserTransactions { get; set; }
    }
}
