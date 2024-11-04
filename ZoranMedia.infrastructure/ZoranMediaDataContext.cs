using Microsoft.EntityFrameworkCore;
using ZoranMedia.Domain.Entities;
using ZoranMedia.Domain.Entities.Enums;

namespace ZoranMedia.Infrastructure
{
    public class ZoranMediaDataContext : DbContext
    {
        public ZoranMediaDataContext(DbContextOptions<ZoranMediaDataContext> options) : base(options)
        {
        }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Client> Clients { get; set; }  
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Configurations)
                .WithOne(c => c.Client)
                .HasForeignKey(c => c.ClientID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Campaigns)
                .WithMany(c => c.Clients)
                .UsingEntity(j => j.ToTable("ClientCampaigns"));

            modelBuilder.Entity<Campaign>()
                .HasOne(c => c.Template)
                .WithOne(t => t.Campaign)
                .HasForeignKey<Campaign>(c => c.TemplateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Campaign>()
                .HasMany(c => c.Emails)
                .WithOne(e => e.Campaign)
                .HasForeignKey(e => e.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Email>()
                .Property(e => e.Status)
                .HasDefaultValue(EmailStatus.Pending);
        }

    }
}
