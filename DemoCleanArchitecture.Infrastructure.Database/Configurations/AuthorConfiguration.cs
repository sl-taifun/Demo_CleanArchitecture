using DemoCleanArchitecture.Domain.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.Infrastructure.Database.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(a => a.Id)
                .HasName("PK_Author")
                .IsClustered();
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(a => a.Pseudo)
                .HasMaxLength(50)
                .IsUnicode();
            builder.Property(a => a.BirthDate)
                .HasColumnType("date");

            builder.HasIndex(a => new { a.LastName, a.FirstName })
                .HasDatabaseName("IDX_Author__Name");
        }
    }
}
