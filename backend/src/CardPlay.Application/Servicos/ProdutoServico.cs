using CardPlay.Application.Contratos.Repositorios;
using CardPlay.Application.Contratos.Servicos;
using CardPlay.Application.Dtos;
using CardPlay.Application.Mapeamentos;

namespace CardPlay.Application.Servicos;

public class ProdutoServico : IProdutoServico
{
    private readonly IProdutoRepositorio _produtoRepositorio;

    public ProdutoServico(IProdutoRepositorio produtoRepositorio)
    {
        _produtoRepositorio = produtoRepositorio;
    }

    public async Task<IReadOnlyCollection<ProdutoResposta>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var produtos = await _produtoRepositorio.ListarAsync(cancellationToken);
        return produtos.Select(MapeadorProduto.ParaResposta).ToArray();
    }
}
