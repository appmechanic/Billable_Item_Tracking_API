using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BillableTrackingApi.Models
{
    public class BillableItemEventRecord
    {
        [Key]
        public Guid ID { get; set; }

        [ForeignKey("Patient")]
        public Guid PatientID { get; set; }
        public PatientRecord Patient { get; set; }

        [Required(ErrorMessage = "Event Date is required")]
        public DateTime EventDate { get; set; }

        public TimeSpan EventTime { get; set; }

        [ForeignKey("SelectedItem")]
        public Guid SelectedItemID { get; set; }
        public BillableItemRecord SelectedItem { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SelectedItemCurrentPrice { get; set; }

        public string Notes { get; set; }

        public bool Invoiced { get; set; }

        public Guid? InvoiceID { get; set; }
    }
}
