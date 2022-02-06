using Bazzar.Domain.Advertisements.Entities;
using Bazzar.Domain.Advertisements.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Infrastructures.Data.SQLServer.Advertisements
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(c => c.Price).HasConversion(c => c.Value.Value, d => Price.FromLong(d));
            builder.Property(c => c.OwnerId).HasConversion(c => c.Value.ToString(), d => UserId.FromString(d));
            builder.Property(c => c.ApprovedBy).HasConversion(c => c.Value.ToString(), d => UserId.FromString(d));
            builder.Property(c => c.Text).HasConversion(c => c.Value, d => AdvertisementText.FromString(d));
            builder.Property(c => c.Title).HasConversion(c => c.Value, d => AdvertisementTitle.FromString(d));
        }
    }
}
