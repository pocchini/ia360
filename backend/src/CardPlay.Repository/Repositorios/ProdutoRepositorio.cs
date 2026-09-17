using CardPlay.Application.Contratos.Repositorios;
using CardPlay.Domain.Entidades;
using CardPlay.Repository.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CardPlay.Repository.Repositorios;

public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly CardPlayDbContext _contexto;

    public ProdutoRepositorio(CardPlayDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<IReadOnlyCollection<Produto>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _contexto.Produtos
            .AsNoTracking()
            .OrderBy(produto => produto.Nome)
            .ToListAsync(cancellationToken);
    }
}
