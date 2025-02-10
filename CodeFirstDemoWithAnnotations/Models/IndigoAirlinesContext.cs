using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemoWithAnnotations.Models;

public partial class IndigoAirlinesContext : DbContext
{
    public IndigoAirlinesContext()
    {
    }

    public IndigoAirlinesContext(DbContextOptions<IndigoAirlinesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.\\sqlexpress;Database=IndigoAirlines;Integrated security=true;Trust server certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Custid).HasName("PK__Customer__049D3E8131822DFC");

            entity.ToTable("Customer");

            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.SeatNo).HasName("PK__Airlines__3116FB41C64FCBF4");

            entity.ToTable("Passenger");

            entity.Property(e => e.SeatNo).ValueGeneratedNever();
            entity.Property(e => e.Destination)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeatTyoe)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StartingPoint)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
