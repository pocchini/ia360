using CardPlay.Application.Contratos.Repositorios;
using CardPlay.Application.Contratos.Servicos;
using CardPlay.Application.Dtos;
using CardPlay.Application.Mapeamentos;
using CardPlay.Domain.Entidades;
using CardPlay.Domain.Excecoes;

namespace CardPlay.Application.Servicos;

public class CartaoServico : ICartaoServico
{
    private readonly ICartaoRepositorio _cartaoRepositorio;

    public CartaoServico(ICartaoRepositorio cartaoRepositorio)
    {
        _cartaoRepositorio = cartaoRepositorio;
    }

    public async Task<CartaoResposta> SolicitarAsync(
        SolicitarCartaoRequisicao requisicao,
        CancellationToken cancellationToken = default)
    {
        var cartao = Cartao.Solicitar(requisicao.NomeTitular);
        await _cartaoRepositorio.AdicionarAsync(cartao, cancellationToken);
        await _cartaoRepositorio.SalvarAlteracoesAsync(cancellationToken);
        return MapeadorCartao.ParaResposta(cartao);
    }

    public async Task<CartaoResposta> ObterAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cartao = await ObterCartaoAsync(id, cancellationToken);
        return MapeadorCartao.ParaResposta(cartao);
    }

    public async Task<CartaoResposta> RecarregarAsync(
        Guid id,
        RecargaRequisicao requisicao,
        CancellationToken cancellationToken = default)
    {
        var cartao = await ObterCartaoAsync(id, cancellationToken);
        var movimentacao = cartao.Recarregar(requisicao.Valor, requisicao.Descricao);
        _cartaoRepositorio.AdicionarMovimentacao(movimentacao);
        await _cartaoRepositorio.SalvarAlteracoesAsync(cancellationToken);
        return MapeadorCartao.ParaResposta(cartao);
    }

    public async Task<IReadOnlyCollection<MovimentacaoResposta>> ListarMovimentacoesAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var cartao = await ObterCartaoAsync(id, cancellationToken);
        return cartao.Movimentacoes
            .OrderByDescending(movimentacao => movimentacao.DataHora)
            .Select(MapeadorCartao.ParaResposta)
            .ToArray();
    }

    private async Task<Cartao> ObterCartaoAsync(Guid id, CancellationToken cancellationToken)
    {
        var cartao = await _cartaoRepositorio.ObterPorIdAsync(id, cancellationToken);
        if (cartao is null)
        {
            throw new CartaoNaoEncontradoException(id);
        }

        return cartao;
    }
}
