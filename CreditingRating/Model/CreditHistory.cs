using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditingRating.Model
{
    [Table("credit_history")]
    public class CreditHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("credit_histoy_id")]
        public int Id { get; set; }

        [NotMapped]
        public List<double> PaymentHistory { get; set; }

        [Required]
        [Column("client_credit_utilization")]
        public double CreditUtilization { get; set; }

        [Required]
        [Column("client_age")]
        public int CreditHistoryLength { get; set; }

        [Required]
        [Column("client_credit_recent_inquiries")]
        public int recentInquiries { get; set; }
    }
}
