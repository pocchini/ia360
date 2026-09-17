using CardPlay.Application.Dtos;

namespace CardPlay.Application.Contratos.Servicos;

public interface IProdutoServico
{
    Task<IReadOnlyCollection<ProdutoResposta>> ListarAsync(CancellationToken cancellationToken = default);
}
