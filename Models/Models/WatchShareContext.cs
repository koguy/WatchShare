using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models.Models
{
    public partial class WatchShareContext : DbContext
    {
        public WatchShareContext()
        {
        }

        public WatchShareContext(DbContextOptions<WatchShareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cinemaddict> Cinemaddict { get; set; }
        public virtual DbSet<CinemaddictVideoContent> CinemaddictVideoContent { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Connection> Connection { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<VideoContent> VideoContent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Artem-PC;Database=WatchShare;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cinemaddict>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DtCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);
            });

            modelBuilder.Entity<CinemaddictVideoContent>(entity =>
            {
                entity.ToTable("Cinemaddict_VideoContent");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CinemaddictId).HasColumnName("CinemaddictID");

                entity.Property(e => e.DtCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(3, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.VideoContentId).HasColumnName("VideoContentID");

                entity.HasOne(d => d.Cinemaddict)
                    .WithMany(p => p.CinemaddictVideoContent)
                    .HasForeignKey(d => d.CinemaddictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CinemaddictID_Cinemaddict_VideoContent");

                entity.HasOne(d => d.VideoContent)
                    .WithMany(p => p.CinemaddictVideoContent)
                    .HasForeignKey(d => d.VideoContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoContentID_Cinemaddict_VideoContent");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CinemaddictId).HasColumnName("CinemaddictID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DtCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VideoContentId).HasColumnName("VideoContentID");

                entity.HasOne(d => d.Cinemaddict)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.CinemaddictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CinemaddictID_Comment");

                entity.HasOne(d => d.VideoContent)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.VideoContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoContentID_Comment");
            });

            modelBuilder.Entity<Connection>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DtCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MyFriendId).HasColumnName("MyFriendID");

                entity.Property(e => e.MyId).HasColumnName("MyID");

                entity.HasOne(d => d.MyFriend)
                    .WithMany(p => p.ConnectionMyFriend)
                    .HasForeignKey(d => d.MyFriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyFriendID_Connection");

                entity.HasOne(d => d.My)
                    .WithMany(p => p.ConnectionMy)
                    .HasForeignKey(d => d.MyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyId_Connection");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountKey)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AccountSecret)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CinemaddictId).HasColumnName("CinemaddictID");

                entity.Property(e => e.ConfirmationCode).HasMaxLength(50);

                entity.Property(e => e.DtCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Cinemaddict)
                    .WithMany(p => p.Login)
                    .HasForeignKey(d => d.CinemaddictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CinemaddictId_Login");
            });

            modelBuilder.Entity<VideoContent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.DtCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Images)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(3, 2)")
                    .HasDefaultValueSql("((0.00))");
            });
        }
    }
}
