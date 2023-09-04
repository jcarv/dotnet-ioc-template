namespace DotNet.IoC.Template.Data.EFCore.Mappings
{
    using DotNet.IoC.Template.Domain.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class PlayerMapping : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");

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
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.TeamId)
                .HasColumnName("TeamId");

            builder.HasOne(x => x.Team)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
