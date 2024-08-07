namespace financeiro_back.Models;

public class Operacao
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public double Valor { get; set; }

    public Operacao() { }

    public Operacao(DateTime data, double valor)
    {
        this.Id = Guid.NewGuid();
        this.Data = data;
        this.Valor = valor;
    }
}