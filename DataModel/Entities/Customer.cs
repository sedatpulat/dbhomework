using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Entities
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        [Column("customerid")]
        public int CustomerId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("surname")]
        public string Surname { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("dateofbirth")]
        public DateTime DateOfBirth { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("gender")]
        public string Gender { get; set; }

    }
}
