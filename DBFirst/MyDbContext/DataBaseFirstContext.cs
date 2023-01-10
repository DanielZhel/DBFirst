using System;
using System.Collections.Generic;
using DBFirst.MyDbContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBFirst.MyDbContext;

public partial class DataBaseFirstContext : DbContext
{
    public DataBaseFirstContext()
    {
    }

    public DataBaseFirstContext(DbContextOptions<DataBaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DataBaseFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coach>(entity =>
        {
            entity.ToTable("Coach");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Age)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Exp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Age)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Level)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Team).WithMany(p => p.Players)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Player_Team");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Coach).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CoachId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Team");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
