namespace financeiro_back.Erros;

public class NotFoundException : Exception
{
    public NotFoundException() {}

    public NotFoundException(string msg) 
        : base(msg){}

    public NotFoundException(string msg, Exception internalError) 
        : base(msg, internalError) {}
}