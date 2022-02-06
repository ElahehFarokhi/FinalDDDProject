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
    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.Property(c => c.Location).HasConversion(c => c.URL, d => PictureURL.FromString(d));
            builder.OwnsOne(c => c.Size);
        }
    }
}
