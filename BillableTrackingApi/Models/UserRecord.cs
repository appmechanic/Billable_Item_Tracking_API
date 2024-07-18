using System.ComponentModel.DataAnnotations;

namespace BillableTrackingApi.Models
{
    public class UserRecord
    {
        [Key]
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string ApprovedUserDeviceName { get; set; }
        public bool IsVerified { get; set; }
    }
}
