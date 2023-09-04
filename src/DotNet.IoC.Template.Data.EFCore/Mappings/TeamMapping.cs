using DotNet.IoC.Template.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DotNet.IoC.Template.Data.EFCore.Mappings
{
    internal class TeamMapping : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.NameAlias)
                .HasColumnName("NameAlias")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Observations)
                .HasColumnName("Observations")
                .HasMaxLength(2040);

            builder.Property(x => x.CountryId)
                .HasColumnName("CountryId");

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
