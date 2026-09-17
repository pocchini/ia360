using CardPlay.Domain.Entidades;

namespace CardPlay.Application.Contratos.Repositorios;

public interface ICartaoRepositorio
{
    Task<Cartao?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AdicionarAsync(Cartao cartao, CancellationToken cancellationToken = default);
    void AdicionarMovimentacao(MovimentacaoCartao movimentacao);
    Task SalvarAlteracoesAsync(CancellationToken cancellationToken = default);
}
