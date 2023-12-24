using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Entities
{
    [Table("accidents")]
    public class Accidents
    {
        [Key]
        [Column("accidentid")]
        public int AccidentId { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("damageamount")]
        public Decimal DamageAmount { get; set; }
        [Column("Location")]
        public string Location { get; set; }
        [Column("carid")]
        public int CarId { get; set; }
    }
}
