using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BDnew_class.Models
{
    public partial class CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext : DbContext
    {
        public CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext()
        {
        }

        public CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext(DbContextOptions<CUSERSKAHASDESKTOPBDO_GUIDE_CLASSMDFContext> options)
            : base(options)
        {
            
                Database.EnsureCreated();
            
        }

        public virtual DbSet<Class> Class { get; set; }
        public DbSet<User> User { get; set; }
        public virtual DbSet<Crystal> Crystal { get; set; }
        public virtual DbSet<Farm> Farm { get; set; }
        public virtual DbSet<Gear> Gear { get; set; }
        public virtual DbSet<Put> Put { get; set; }
        public virtual DbSet<Spell> Spell { get; set; }
        public virtual DbSet<SpellClass> SpellClass { get; set; }
        public virtual DbSet<Spot> Spot { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=C:\\USERS\\KAHAS\\DESKTOP\\BDO_GUIDE_CLASS.MDF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClass)
                    .HasName("PK__Class__1BBE1AA9C982FCD9");

                entity.Property(e => e.IdClass)
                    .HasColumnName("ID_class")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassDescription)
                    .HasColumnName("Class_description")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClassVid)
                    .HasColumnName("Class_vid")
                    .HasColumnType("text");

                entity.Property(e => e.NameClass)
                    .IsRequired()
                    .HasColumnName("Name_class")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Crystal>(entity =>
            {
                entity.HasKey(e => e.IdCrystal)
                    .HasName("PK__Crystal__4F71E09D7A2CFD12");

                entity.Property(e => e.IdCrystal)
                    .HasColumnName("ID_crystal")
                    .ValueGeneratedNever();

                entity.Property(e => e.CrystalDescription)
                    .HasColumnName("Crystal_description")
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CrystalName)
                    .IsRequired()
                    .HasColumnName("Crystal_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Farm>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.WhatAClass).HasColumnName("What_a_class");

                entity.Property(e => e.WhatASpot).HasColumnName("What_a_spot");

                entity.HasOne(d => d.WhatAClassNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.WhatAClass)
                    .HasConstraintName("FK__Farm__What_a_cla__7F2BE32F");

                entity.HasOne(d => d.WhatASpotNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.WhatASpot)
                    .HasConstraintName("FK__Farm__What_a_spo__00200768");
            });

            modelBuilder.Entity<Gear>(entity =>
            {
                entity.HasKey(e => e.IdGear)
                    .HasName("PK__Gear__0892FE041832A9DE");

                entity.Property(e => e.IdGear)
                    .HasColumnName("ID_gear")
                    .ValueGeneratedNever();

                entity.Property(e => e.GearClass)
                    .HasColumnName("Gear_class")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearDescription)
                    .HasColumnName("Gear_description")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GearGif)
                    .HasColumnName("Gear_gif")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Put>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.WhatAClass).HasColumnName("What_a_class");

                entity.Property(e => e.WhatACrystal).HasColumnName("What_a_crystal");

                entity.HasOne(d => d.WhatAClassNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.WhatAClass)
                    .HasConstraintName("FK__Put__What_a_clas__7C4F7684");

                entity.HasOne(d => d.WhatACrystalNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.WhatACrystal)
                    .HasConstraintName("FK__Put__What_a_crys__7D439ABD");
            });

            modelBuilder.Entity<Spell>(entity =>
            {
                entity.HasKey(e => e.IdSpell)
                    .HasName("PK__Spell__BFB896DA78942976");

                entity.Property(e => e.IdSpell)
                    .HasColumnName("ID_spell")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassId).HasColumnName("Class_Id");

                entity.Property(e => e.NameSpell)
                    .HasColumnName("Name_spell")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SpellDescription)
                    .HasColumnName("Spell_description")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SpellVid)
                    .HasColumnName("Spell_vid")
                    .HasColumnType("text");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Spell)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Spell_Class");
            });

            modelBuilder.Entity<SpellClass>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.SpellId })
                    .HasName("PK__Spell_cl__C3998D2645D70D1E");

                entity.ToTable("Spell_class");

                entity.Property(e => e.ClassId).HasColumnName("Class_id");

                entity.Property(e => e.SpellId).HasColumnName("Spell_id");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.SpellClass)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Spell_cla__Class__02FC7413");

                entity.HasOne(d => d.Spell)
                    .WithMany(p => p.SpellClass)
                    .HasForeignKey(d => d.SpellId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Spell_cla__Spell__03F0984C");
            });

            modelBuilder.Entity<Spot>(entity =>
            {
                entity.HasKey(e => e.IdSpot)
                    .HasName("PK__spot__FAB4BAEEB3BD4E41");

                entity.ToTable("spot");

                entity.Property(e => e.IdSpot)
                    .HasColumnName("ID_spot")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameSpot)
                    .IsRequired()
                    .HasColumnName("Name_spot")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SpotDescription)
                    .HasColumnName("Spot_description")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SpotGif)
                    .HasColumnName("Spot_gif")
                    .HasColumnType("image");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
