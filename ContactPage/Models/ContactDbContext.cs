using Microsoft.EntityFrameworkCore;

namespace ContactPage.Models
{
    public partial class ContactDbContext : DbContext
    {
        public ContactDbContext()
        {
        }

        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactMessages> ContactMessages { get; set; }
        public virtual DbSet<MessagesAreaOfInterest> MessagesAreaOfInterest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactMessages>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactMessage)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(22)
                    .IsUnicode(false);

                entity.HasOne(d => d.AreaOfInterestNavigation)
                    .WithMany(p => p.ContactMessages)
                    .HasForeignKey(d => d.AreaOfInterest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContactMe__AreaO__4BAC3F29");
            });

            modelBuilder.Entity<MessagesAreaOfInterest>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AreaOfInterest)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
