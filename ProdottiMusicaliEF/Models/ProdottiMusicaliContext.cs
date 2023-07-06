﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProdottiMusicaliEF.Models;

public partial class ProdottiMusicaliContext : DbContext
{
    public ProdottiMusicaliContext()
    {
    }

    public ProdottiMusicaliContext(DbContextOptions<ProdottiMusicaliContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cd> Cds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-OK3FRIM1;Database=ProdottiMusicali;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cd>(entity =>
        {
            entity.ToTable("CD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anno).HasColumnName("anno");
            entity.Property(e => e.Artista)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("artista");
            entity.Property(e => e.Titolo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("titolo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
