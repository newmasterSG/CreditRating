using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditingRating.Model
{
    [Table("Bank")]
    public class Bank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("bank_id")]
        public int Id { get; set; }

        public IList<BankClient> BankClients { get; set; }
    }
}
