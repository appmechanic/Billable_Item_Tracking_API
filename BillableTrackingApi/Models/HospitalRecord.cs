using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillableTrackingApi.Models
{
    public class HospitalRecord
    {
        [Key]
        public Guid HospitalID { get; set; }
        
        public Guid UserID { get; set; }
        
        public string ProviderNumber { get; set; }
        public string LSPN { get; set; }
        public bool IsVerified { get; set; }
        [ForeignKey("UserID")]
        public virtual UserRecord? UserRecord { get; set; }
    }
}
