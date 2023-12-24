using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Entities
{
    [Table("car")]
    public class Car
    {
        [Key]
        [Column("carid")]
        public int CarId { get; set; }
        [Column("model")]
        public string Model { get; set; }
        [Column("brand")]
        public string Brand { get; set; }
        [Column("year")]
        public string Year { get; set; }
        [Column("submodel")]
        public string SubModel { get; set; }
        [Column("engineno")]
        public string EngineNo { get; set; }
        [Column("color")]
        public string Color { get; set; }
        [Column("plate")]
        public string Plate { get; set; }
        [Column("customerid")]
        public int CustomerId { get; set; }
    }
}
