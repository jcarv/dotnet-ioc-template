namespace DotNet.IoC.Template.Data.EFCore.Mappings
{
    using DotNet.IoC.Template.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.IsoCode)
                .HasColumnName("IsoCode")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.NameAlias)
                .HasColumnName("NameAlias")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.IsoCodeAlias)
                .HasColumnName("IsoCodeAlias")
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasIndex(x => x.NameAlias)
                .IsUnique();

            builder.HasIndex(x => x.IsoCode)
                .IsUnique();

            builder.HasIndex(x => x.IsoCodeAlias)
                .IsUnique();

            builder.Property(x => x.Observations)
                .HasColumnName("Observations")
                .HasMaxLength(2040);
        }
    }
}
