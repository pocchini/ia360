namespace CardPlay.Application.Dtos;

public class MovimentacaoResposta
{
    public Guid Id { get; init; }
    public decimal Valor { get; init; }
    public string Descricao { get; init; } = string.Empty;
    public DateTime DataHora { get; init; }
}
