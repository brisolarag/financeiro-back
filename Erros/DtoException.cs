namespace financeiro_back.Erros;

public class DtoException : Exception
{
    public DtoException() {}

    public DtoException(string msg) 
        : base(msg){}

    public DtoException(string msg, Exception internalError) 
        : base(msg, internalError) {}
}