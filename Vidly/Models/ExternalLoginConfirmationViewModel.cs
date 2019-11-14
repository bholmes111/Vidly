using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Drivers License")]
        public string DriversLicense { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        [MaxLength(50)]
        public string Phone { get; set; }
    }
}