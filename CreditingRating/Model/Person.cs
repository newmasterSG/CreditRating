using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditingRating.Model
{
    [Table("customer_contact")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("person_id")]
        public int Id { get; set; }

        [Required]
        [Column("person_name")]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [Column("person_surname")]
        public string Surname
        {
            get;
            set;
        }

        [Required]
        [Column("person_gender")]
        public string Gender
        {
            get;
            set;
        }

        [Required]
        [Column("person_birthday")]
        public string Birthday
        {
            get;
            set;
        }

        [Required]
        [Column("person_age")]
        public int Age
        {
            get;
            set;
        }

        public Client Client { get; set; }
    }
}
