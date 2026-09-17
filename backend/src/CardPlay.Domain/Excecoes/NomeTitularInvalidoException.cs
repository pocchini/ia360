namespace CardPlay.Domain.Excecoes;

public class NomeTitularInvalidoException : Exception
{
    public NomeTitularInvalidoException()
        : base("Informe o nome do titular para solicitar o cartão.")
    {
    }
}
