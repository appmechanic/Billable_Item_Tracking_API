namespace BillableTrackingApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PatientRecord
    {
        [Key]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; } // Sensitive, should be encrypted

        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50)]
        public string FirstName { get; set; } // Sensitive, should be encrypted

        [MaxLength(50)]
        public string Middle { get; set; } // Sensitive, should be encrypted

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(50)]
        public string LastName { get; set; } // Sensitive, should be encrypted

        [ForeignKey("InsuranceCompanyRecord")]
        public Guid InsuranceCompanyID { get; set; }
        public virtual InsuranceCompanyRecord InsuranceCompanyRecord { get; set; }

        [Required(ErrorMessage = "Insurance Member Number is required")]
        [MaxLength(20)]
        public string InsuranceMemberNumber { get; set; } // Sensitive, should be encrypted

        [Required(ErrorMessage = "Medicare Number is required")]
        [MaxLength(20)]
        public string MedicareNumber { get; set; } // Sensitive, should be encrypted

        [Required(ErrorMessage = "Address Line 1 is required")]
        [MaxLength(100)]
        public string Address1 { get; set; } // Sensitive, should be encrypted

        [MaxLength(100)]
        public string Address2 { get; set; } // Sensitive, should be encrypted

        [Required(ErrorMessage = "City is required")]
        [MaxLength(50)]
        public string City { get; set; } // Sensitive, should be encrypted

        [Required(ErrorMessage = "State is required")]
        [MaxLength(50)]
        public string State { get; set; } // Sensitive, should be encrypted

        [Required(ErrorMessage = "Country is required")]
        [MaxLength(50)]
        public string Country { get; set; } // Sensitive, should be encrypted

        [Required(ErrorMessage = "Postcode is required")]
        [MaxLength(10)]
        public string PostCode { get; set; } // Sensitive, should be encrypted

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; } // Sensitive, should be encrypted

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [ForeignKey("ReferralSourceRecord")]
        public Guid ReferralID { get; set; }
        public virtual ReferralSourceRecord ReferralSourceRecord { get; set; }

        [Required(ErrorMessage = "Referral Date is required")]
        public DateTime ReferralDate { get; set; }

        [ForeignKey("HospitalRecord")]
        public Guid HospitalID { get; set; }
        public virtual HospitalRecord HospitalRecord { get; set; }
    }

}
