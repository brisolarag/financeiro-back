namespace financeiro_back.Models.Entradas;

public class Entrada : Operacao
{
    public string DeQuem { get; set; }

    public Entrada() { }

    public Entrada(DateTime data, double valor, string deQuem)
        : base(data, valor)
    {
        this.DeQuem = deQuem;
    }
}