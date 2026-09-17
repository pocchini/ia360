using CardPlay.Application.Dtos;

namespace CardPlay.Application.Contratos.Servicos;

public interface ICartaoServico
{
    Task<CartaoResposta> SolicitarAsync(SolicitarCartaoRequisicao requisicao, CancellationToken cancellationToken = default);
    Task<CartaoResposta> ObterAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CartaoResposta> RecarregarAsync(Guid id, RecargaRequisicao requisicao, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<MovimentacaoResposta>> ListarMovimentacoesAsync(Guid id, CancellationToken cancellationToken = default);
}
