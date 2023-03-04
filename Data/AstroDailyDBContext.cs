using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AstroDailyProject.Data
{
    public partial class AstroDailyDBContext : DbContext
    {
        public AstroDailyDBContext()
        {
        }

        public AstroDailyDBContext(DbContextOptions<AstroDailyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aspect> Aspects { get; set; }
        public virtual DbSet<AspectType> AspectTypes { get; set; }
        public virtual DbSet<AstroProfile> AstroProfiles { get; set; }
        public virtual DbSet<Explanation> Explanations { get; set; }
        public virtual DbSet<Horoscope> Horoscopes { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<LifeAttribute> LifeAttributes { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Zodiac> Zodiacs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IGHJL71;Database=AstroDailyDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Aspect>(entity =>
            {
                entity.ToTable("Aspect");

                entity.HasOne(d => d.AspectType)
                    .WithMany(p => p.Aspects)
                    .HasForeignKey(d => d.AspectTypeId)
                    .HasConstraintName("FK__Aspect__AspectTy__286302EC");

                entity.HasOne(d => d.PlanetId1Navigation)
                    .WithMany(p => p.AspectPlanetId1Navigations)
                    .HasForeignKey(d => d.PlanetId1)
                    .HasConstraintName("FK__Aspect__PlanetId__267ABA7A");

                entity.HasOne(d => d.PlanetId2Navigation)
                    .WithMany(p => p.AspectPlanetId2Navigations)
                    .HasForeignKey(d => d.PlanetId2)
                    .HasConstraintName("FK__Aspect__PlanetId__276EDEB3");
            });

            modelBuilder.Entity<AspectType>(entity =>
            {
                entity.ToTable("AspectType");
            });

            modelBuilder.Entity<AstroProfile>(entity =>
            {
                entity.ToTable("AstroProfile");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Aspect)
                    .WithMany(p => p.AstroProfiles)
                    .HasForeignKey(d => d.AspectId)
                    .HasConstraintName("FK__AstroProf__Aspec__32E0915F");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AstroProfiles)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__AstroProf__Custo__30F848ED");

                entity.HasOne(d => d.Explanation)
                    .WithMany(p => p.AstroProfiles)
                    .HasForeignKey(d => d.ExplanationId)
                    .HasConstraintName("FK__AstroProf__Expla__31EC6D26");
            });

            modelBuilder.Entity<Explanation>(entity =>
            {
                entity.ToTable("Explanation");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Explanations)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK__Explanati__House__1B0907CE");

                entity.HasOne(d => d.Planet)
                    .WithMany(p => p.Explanations)
                    .HasForeignKey(d => d.PlanetId)
                    .HasConstraintName("FK__Explanati__Plane__1BFD2C07");

                entity.HasOne(d => d.Zodiac)
                    .WithMany(p => p.Explanations)
                    .HasForeignKey(d => d.ZodiacId)
                    .HasConstraintName("FK__Explanati__Zodia__1A14E395");
            });

            modelBuilder.Entity<Horoscope>(entity =>
            {
                entity.ToTable("Horoscope");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.HasOne(d => d.Aspect)
                    .WithMany(p => p.Horoscopes)
                    .HasForeignKey(d => d.AspectId)
                    .HasConstraintName("FK__Horoscope__Aspec__2D27B809");

                entity.HasOne(d => d.LifeAttribute)
                    .WithMany(p => p.Horoscopes)
                    .HasForeignKey(d => d.LifeAttributeId)
                    .HasConstraintName("FK__Horoscope__LifeA__2E1BDC42");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.ToTable("House");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<LifeAttribute>(entity =>
            {
                entity.ToTable("LifeAttribute");

                entity.Property(e => e.Routine).HasMaxLength(2000);

                entity.Property(e => e.Self).HasMaxLength(2000);

                entity.Property(e => e.SexLove).HasMaxLength(2000);

                entity.Property(e => e.SocialLife).HasMaxLength(2000);

                entity.Property(e => e.Spirituality).HasMaxLength(2000);

                entity.Property(e => e.ThinkingCreativity).HasMaxLength(2000);
            });

            modelBuilder.Entity<Planet>(entity =>
            {
                entity.ToTable("Planet");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("Quote");

                entity.Property(e => e.Script).HasMaxLength(2000);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Username, "UQ__User__536C85E40B37D7FE")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UQ__User__5C7E359EA0F3204F")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__User__A9D1053452729A1F")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Otp)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("OTP");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleId__21B6055D");
            });

            modelBuilder.Entity<Zodiac>(entity =>
            {
                entity.ToTable("Zodiac");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
