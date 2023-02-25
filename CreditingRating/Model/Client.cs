using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditingRating.Model
{
    [Table("client")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("client_id")]
        public int Id { get; set; }

        [Required]
        [Column("client_salary")]
        public double Salary { get; set; }

        [ForeignKey("CreditHistory")]
        [Column("credit_histoy_id")]
        public int CreditHistoryId { get; set; }

        [ForeignKey("Person")]
        [Column("person_id")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public CreditHistory CreditHistory { get; set; }

        public IList<BankClient> ClientBanks { get; set; }
    }
}
