using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditingRating.Model
{
    [Table("client_credit")]
    public class Credit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("client_id")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public string Name { get; set; }
        public int AvailableCredit { get; set; }
        public double MoneySpent { get; set; }

        public int LatePayment { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}
