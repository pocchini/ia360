using CardPlay.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CardPlay.Repository.Contexto;

public class CardPlayDbContext : DbContext
{
    public CardPlayDbContext(DbContextOptions<CardPlayDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cartao> Cartoes => Set<Cartao>();
    public DbSet<MovimentacaoCartao> Movimentacoes => Set<MovimentacaoCartao>();
    public DbSet<Produto> Produtos => Set<Produto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardPlayDbContext).Assembly);
    }
}
