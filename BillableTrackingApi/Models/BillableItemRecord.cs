using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BillableTrackingApi.Models
{


    public class BillableItemRecord
    {
        [Key]
        public Guid ID { get; set; }

        [ForeignKey("InsuranceCompanyRecord")]
        public Guid InsuranceCompanyID { get; set; }
        public virtual InsuranceCompanyRecord InsuranceCompanyRecord { get; set; }

        [Required(ErrorMessage = "Item Code is required")]
        [MaxLength(20)]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "Item Name is required")]
        [MaxLength(100)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Item Price is required")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ItemPrice { get; set; }

        [Required(ErrorMessage = "Date Modified is required")]
        public DateTime DateModified { get; set; }
    }

}
