using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.EntityConfigurations
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId)
                .WillCascadeOnDelete(false);

            //HasRequired(r => r.Rental)
            //    .WithRequiredPrincipal(m => m.Movie);
        }
    }
}