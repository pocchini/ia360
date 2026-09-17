using CardPlay.Domain.Entidades;
using CardPlay.Domain.Excecoes;

namespace CardPlay.Tests;

public class CartaoTestes
{
    [Fact]
    public void Solicitar_ComNomeValido_CriaCartaoComSaldoZero()
    {
        var cartao = Cartao.Solicitar("Ana Silva");

        Assert.NotEqual(Guid.Empty, cartao.Id);
        Assert.Equal("Ana Silva", cartao.NomeTitular);
        Assert.StartsWith("CP-", cartao.CodigoAmigavel);
        Assert.Equal(9, cartao.CodigoAmigavel.Length);
        Assert.Equal(0m, cartao.Saldo);
        Assert.Empty(cartao.Movimentacoes);
        Assert.True(cartao.DataCriacao <= DateTime.UtcNow);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("A")]
    public void Solicitar_ComNomeInvalido_Rejeita(string nome)
    {
        Assert.Throws<NomeTitularInvalidoException>(() => Cartao.Solicitar(nome));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-15.5)]
    public void Recarregar_ValorIgualOuInferiorAZero_Rejeita(decimal valor)
    {
        var cartao = Cartao.Solicitar("Bruno");

        Assert.Throws<RecargaInvalidaException>(() => cartao.Recarregar(valor, "Tentativa"));
        Assert.Equal(0m, cartao.Saldo);
        Assert.Empty(cartao.Movimentacoes);
    }

    [Fact]
    public void Recarregar_ValorValido_AtualizaSaldo()
    {
        var cartao = Cartao.Solicitar("Carla");

        cartao.Recarregar(50.25m, "Recarga inicial");

        Assert.Equal(50.25m, cartao.Saldo);
    }

    [Fact]
    public void Recarregar_ValorValido_RegistraMovimentacao()
    {
        var cartao = Cartao.Solicitar("Diego");

        cartao.Recarregar(20m, "Recarga da semana");

        var movimentacao = Assert.Single(cartao.Movimentacoes);
        Assert.Equal(20m, movimentacao.Valor);
        Assert.Equal("Recarga da semana", movimentacao.Descricao);
        Assert.Equal(cartao.Id, movimentacao.CartaoId);
        Assert.True(movimentacao.DataHora <= DateTime.UtcNow);
    }

    [Fact]
    public void Recarregar_SemDescricao_UsaDescricaoPadrao()
    {
        var cartao = Cartao.Solicitar("Elena");

        cartao.Recarregar(10m, "   ");

        Assert.Equal("Recarga", Assert.Single(cartao.Movimentacoes).Descricao);
    }
}
