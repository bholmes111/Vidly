using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    
    public partial class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public bool IsDelinquent { get; set; }

        public MembershipType MembershipType { get; set; }

        public int MembershipTypeId { get; set; }
        
    }
}