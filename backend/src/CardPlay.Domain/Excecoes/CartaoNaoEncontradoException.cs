namespace CardPlay.Domain.Excecoes;

public class CartaoNaoEncontradoException : Exception
{
    public CartaoNaoEncontradoException(Guid id)
        : base($"Cartão {id} não foi encontrado.")
    {
        Id = id;
    }

    public Guid Id { get; }
}
