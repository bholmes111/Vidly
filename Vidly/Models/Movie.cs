using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        //public virtual Rental Rental { get; set; }
    }
}