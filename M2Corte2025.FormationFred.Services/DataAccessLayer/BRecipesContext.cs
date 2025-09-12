using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace M2Corte2025.FormationFred.Services.DataAccessLayer;

public partial class BRecipesContext : DbContext
{
    public BRecipesContext()
    {
    }

    public BRecipesContext(DbContextOptions<BRecipesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TRecipe> TRecipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=bRecipes;User id=sa;Password=Formation@31;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TRecipe>(entity =>
        {
            entity.ToTable("tRecipes");

            entity.HasIndex(e => e.Title, "IX_tRecipes");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
