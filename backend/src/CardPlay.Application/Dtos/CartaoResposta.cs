namespace CardPlay.Application.Dtos;

public class CartaoResposta
{
    public Guid Id { get; init; }
    public string NomeTitular { get; init; } = string.Empty;
    public string CodigoAmigavel { get; init; } = string.Empty;
    public decimal Saldo { get; init; }
    public DateTime DataCriacao { get; init; }
}
