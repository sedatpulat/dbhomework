using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Entities
{
    [Table("insurancepolicy")]
    public class InsurancePolicy
    {
        [Key]
        [Column("policyid")]
        public int PolicyId { get; set; }
        [Column("policynumber")]
        public string PolicyNumber { get; set; }
        [Column("policystartdate")]
        public DateTime PolicyStartDate { get; set; }
        [Column("policyenddate")]
        public DateTime PolicyEndDate { get; set; }
        [Column("covargetype")]
        public string CovargeType { get; set; }
        [Column("totalcovargeamount")]
        public decimal TotalCovargeAmount { get; set; }
        [Column("carid")]
        public  int CarId { get; set; }
    }
}
