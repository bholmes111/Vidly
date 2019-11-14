using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
    }
    public partial class CustomerMetadata
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}