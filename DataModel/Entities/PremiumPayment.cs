using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Entities
{
    [Table("premiumpayment")]
    public class PremiumPayment
    {
        [Key]
        [Column("paymentid")]
        public int PaymentId { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("paymentdate")]
        public DateTime PaymentDate { get; set; }
        [Column("duedate")]
        public DateTime DueDate { get; set; }
        [Column("paymentmethod")]
        public string PaymentMethod { get; set; }
        [Column("policyid")]
        public int PolicyId { get; set; }
    }
}
