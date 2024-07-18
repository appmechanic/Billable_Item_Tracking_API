using System.ComponentModel.DataAnnotations;

namespace BillableTrackingApi.Models
{
    public class SiteConfiguration
    {
        [Key]
        public Guid Id { get; set; }
        public required string Company { get; set; }
        public string? ABN { get; set; }
        public required string Address1 { get; set; }
        public string Address2 { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
        public string? PostCode { get; set; }
        public string? AccountName { get; set; }
        public string? AccountBSB { get; set; }
        public string? AccountNumber { get; set; }
        public string? Message { get; set; }
        public string? LogoFileReference { get; set; }
        public string? WebsiteAddress { get; set; }
        public required string WebsiteIPAddress { get; set; }
    }
}
