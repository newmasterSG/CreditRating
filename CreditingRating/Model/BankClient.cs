using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditingRating.Model
{
    public class BankClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("bank_client_id")]
        public int Id { get; set; }

        [ForeignKey("Bank")]
        [Column("bank_id")]
        public int BankId { get; set; }
        public Bank Bank { get; set; }

        [ForeignKey("Client")]
        [Column("client_id")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Column("client_rating")]
        public double Rating { get; set; }
    }
}
