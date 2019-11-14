using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    [MetadataType(typeof(RentalMetadata))]
    public partial class Rental
    {
    }
    public class RentalMetadata
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public Customer Customer { get; set; }
    }
}