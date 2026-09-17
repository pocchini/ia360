using CardPlay.Application.Dtos;
using CardPlay.Domain.Entidades;

namespace CardPlay.Application.Mapeamentos;

public static class MapeadorProduto
{
    public static ProdutoResposta ParaResposta(Produto produto)
    {
        return new ProdutoResposta
        {
            Id = produto.Id,
            Nome = produto.Nome,
            DescricaoCurta = produto.DescricaoCurta,
            Preco = produto.Preco,
            Icone = produto.Icone,
            Disponivel = produto.Disponivel
        };
    }
}
