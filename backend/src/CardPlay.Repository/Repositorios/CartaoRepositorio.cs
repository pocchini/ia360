using CardPlay.Application.Contratos.Repositorios;
using CardPlay.Domain.Entidades;
using CardPlay.Repository.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CardPlay.Repository.Repositorios;

public class CartaoRepositorio : ICartaoRepositorio
{
    private readonly CardPlayDbContext _contexto;

    public CartaoRepositorio(CardPlayDbContext contexto)
    {
        _contexto = contexto;
    }

    public Task<Cartao?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _contexto.Cartoes
            .Include(cartao => cartao.Movimentacoes)
            .FirstOrDefaultAsync(cartao => cartao.Id == id, cancellationToken);
    }

    public async Task AdicionarAsync(Cartao cartao, CancellationToken cancellationToken = default)
    {
        await _contexto.Cartoes.AddAsync(cartao, cancellationToken);
    }

    public void AdicionarMovimentacao(MovimentacaoCartao movimentacao)
    {
        var entrada = _contexto.Entry(movimentacao);
        if (entrada.State == EntityState.Detached)
        {
            _contexto.Movimentacoes.Add(movimentacao);
            return;
        }

        if (entrada.State != EntityState.Added)
        {
            entrada.State = EntityState.Added;
        }
    }

    public Task SalvarAlteracoesAsync(CancellationToken cancellationToken = default)
    {
        return _contexto.SaveChangesAsync(cancellationToken);
    }
}
