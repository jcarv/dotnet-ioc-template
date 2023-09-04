namespace DotNet.IoC.Template.Data.EFCore.Mappings
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using DotNet.IoC.Template.Domain.Models;

    internal class TeamsPlayersMapping : IEntityTypeConfiguration<TeamsPlayers>
    {
        public void Configure(EntityTypeBuilder<TeamsPlayers> builder)
        {
            builder.ToTable("TeamsPlayers");

            builder.HasKey(x => new { x.TeamId, x.PlayerId, x.ContractStart });

            builder.Property(x => x.TeamId)
                .HasColumnName("TeamId")
                .IsRequired();

            builder.Property(x => x.PlayerId)
                .HasColumnName("PlayerId")
                .IsRequired();

            builder.Property(x => x.ContractStart)
                .HasColumnName("ContractStart")
                .IsRequired();

            builder.Property(x => x.ContractEnd)
                .HasColumnName("ContractEnd");

            builder.HasOne(x => x.Team)
                .WithMany(a => a.TeamsPlayers)
                .HasForeignKey(b => b.TeamId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Player)
                .WithMany(a => a.TeamsPlayers)
                .HasForeignKey(b => b.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
