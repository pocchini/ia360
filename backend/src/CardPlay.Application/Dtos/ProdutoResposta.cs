namespace CardPlay.Application.Dtos;

public class ProdutoResposta
{
    public Guid Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string DescricaoCurta { get; init; } = string.Empty;
    public decimal Preco { get; init; }
    public string Icone { get; init; } = string.Empty;
    public bool Disponivel { get; init; }
}
