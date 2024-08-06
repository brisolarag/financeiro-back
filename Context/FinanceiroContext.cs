using financeiro_back.Models;
using Microsoft.EntityFrameworkCore;
using financeiro_back.Models;
using financeiro_back.Models.Saidas;
using financeiro_back.Models.Entradas;

namespace financeiro_back.Context;

public class FinanceiroContext : DbContext
{
    public DbSet<Entrada> Entradas { get; set; }
    public DbSet<Saida> Saidas { get; set; }

    public FinanceiroContext(DbContextOptions<FinanceiroContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Data).IsRequired();
            entity.Property(e => e.Valor).IsRequired();
            entity.Property(e => e.DeQuem).HasMaxLength(60).IsRequired();
        });

        modelBuilder.Entity<Saida>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Data).IsRequired();
            entity.Property(e => e.Valor).IsRequired();
            entity.Property(e => e.Descricao).HasMaxLength(100).IsRequired();
        });
        
        modelBuilder.Entity<Operacao>()
            .ToTable("Operacoes")  
            .HasDiscriminator<string>("Tipo")
            .HasValue<Entrada>("Entrada")
            .HasValue<Saida>("Saida");
        
    }
}