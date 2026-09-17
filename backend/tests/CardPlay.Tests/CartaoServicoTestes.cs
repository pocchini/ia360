using CardPlay.Application.Contratos.Repositorios;
using CardPlay.Application.Dtos;
using CardPlay.Domain.Entidades;
using CardPlay.Domain.Excecoes;
using CardPlay.Application.Servicos;

namespace CardPlay.Tests;

public class CartaoServicoTestes
{
    [Fact]
    public async Task SolicitarAsync_PersisteCartaoComSaldoZero()
    {
        var repositorio = new CartaoRepositorioEmMemoria();
        var servico = new CartaoServico(repositorio);

        var resposta = await servico.SolicitarAsync(new SolicitarCartaoRequisicao { NomeTitular = "Fernanda" });

        Assert.Equal("Fernanda", resposta.NomeTitular);
        Assert.Equal(0m, resposta.Saldo);
        Assert.NotNull(await repositorio.ObterPorIdAsync(resposta.Id));
    }

    [Fact]
    public async Task RecarregarAsync_ValorValido_AtualizaSaldoERegistraMovimentacao()
    {
        var repositorio = new CartaoRepositorioEmMemoria();
        var servico = new CartaoServico(repositorio);
        var cartao = await servico.SolicitarAsync(new SolicitarCartaoRequisicao { NomeTitular = "Gabriel" });

        var atualizado = await servico.RecarregarAsync(
            cartao.Id,
            new RecargaRequisicao { Valor = 40m, Descricao = "Recarga teste" });
        var movimentacoes = await servico.ListarMovimentacoesAsync(cartao.Id);

        Assert.Equal(40m, atualizado.Saldo);
        var movimentacao = Assert.Single(movimentacoes);
        Assert.Equal(40m, movimentacao.Valor);
        Assert.Equal("Recarga teste", movimentacao.Descricao);
        Assert.Equal(2, repositorio.VezesSalvo);
    }

    [Fact]
    public async Task RecarregarAsync_ValorInvalido_NaoAlteraSaldo()
    {
        var repositorio = new CartaoRepositorioEmMemoria();
        var servico = new CartaoServico(repositorio);
        var cartao = await servico.SolicitarAsync(new SolicitarCartaoRequisicao { NomeTitular = "Helena" });

        await Assert.ThrowsAsync<RecargaInvalidaException>(() =>
            servico.RecarregarAsync(cartao.Id, new RecargaRequisicao { Valor = 0m }));

        var consultado = await servico.ObterAsync(cartao.Id);
        Assert.Equal(0m, consultado.Saldo);
        Assert.Empty(await servico.ListarMovimentacoesAsync(cartao.Id));
    }

    private sealed class CartaoRepositorioEmMemoria : ICartaoRepositorio
    {
        private readonly Dictionary<Guid, Cartao> _cartoes = [];

        public int VezesSalvo { get; private set; }

        public Task<Cartao?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _cartoes.TryGetValue(id, out var cartao);
            return Task.FromResult(cartao);
        }

        public Task AdicionarAsync(Cartao cartao, CancellationToken cancellationToken = default)
        {
            _cartoes[cartao.Id] = cartao;
            return Task.CompletedTask;
        }

        public void AdicionarMovimentacao(MovimentacaoCartao movimentacao)
        {
        }

        public Task SalvarAlteracoesAsync(CancellationToken cancellationToken = default)
        {
            VezesSalvo++;
            return Task.CompletedTask;
        }
    }
}
