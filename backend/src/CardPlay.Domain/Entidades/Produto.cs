namespace CardPlay.Domain.Entidades;

public class Produto
{
    private Produto()
    {
        Nome = string.Empty;
        DescricaoCurta = string.Empty;
        Icone = string.Empty;
    }

    public Produto(
        Guid id,
        string nome,
        string descricaoCurta,
        decimal preco,
        string icone,
        bool disponivel)
    {
        Id = id;
        Nome = nome;
        DescricaoCurta = descricaoCurta;
        Preco = preco;
        Icone = icone;
        Disponivel = disponivel;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string DescricaoCurta { get; private set; }
    public decimal Preco { get; private set; }
    public string Icone { get; private set; }
    public bool Disponivel { get; private set; }
}
