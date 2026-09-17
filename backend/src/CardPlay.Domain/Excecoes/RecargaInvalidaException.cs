namespace CardPlay.Domain.Excecoes;

public class RecargaInvalidaException : Exception
{
    public RecargaInvalidaException()
        : base("A recarga deve ter valor maior que zero.")
    {
    }
}
