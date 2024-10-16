using Microsoft.EntityFrameworkCore;


namespace NotificationService.data.Models;

public partial class TmpContext : DbContext
{
    public TmpContext()
    {
    }

    public TmpContext(DbContextOptions<TmpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EfmigrationsHistory2> EfmigrationsHistories { get; set; }

    public virtual DbSet<ImageTrack> ImageTracks { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=195.35.14.162;database=TMP;user=user;password=P@ssW0rd", ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<EfmigrationsHistory2>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<ImageTrack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ProductId, "IX_ImageTracks_productId");

            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Url).HasColumnName("url");

            entity.HasOne(d => d.Product)
                  .WithMany(p => p.ImageTracks)
                  .HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.Product).WithMany(p => p.ImageTracks).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasMany(p => p.ImageTracks)
              .WithOne(i => i.Product)
              .HasForeignKey(i => i.ProductId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
