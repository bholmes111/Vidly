using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.EntityConfigurations
{
    public class RentalConfiguration : EntityTypeConfiguration<Rental>
    {
        public RentalConfiguration()
        {
            /*HasRequired(r => r.Movie)
                .WithRequiredDependent(m => m.Rental);

            HasRequired(r => r.Customer)
                .WithRequiredDependent(c => c.Rental);*/
        }   
    }
}