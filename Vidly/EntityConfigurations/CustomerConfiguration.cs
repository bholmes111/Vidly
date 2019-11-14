using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Vidly.Models;

namespace Vidly.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            //HasRequired(r => r.Rental)
            //    .WithRequiredPrincipal(c => c.Customer);
        }
    }
}