namespace financeiro_back.Models.Saidas;

public class Saida : Operacao
{
    public string Descricao { get; set; } 
    public bool isFatura { get; set; }
    public bool Pago { get; set; }

    public Saida() { }
    public Saida(DateTime data, double valor, string desc, bool isFatura, bool pago) 
        : base(data, valor)
    {
        this.isFatura = isFatura;
        
        if (this.isFatura)
            this.Descricao = $"Fatura - {desc}";
        else
            this.Descricao = desc;
        
        this.Pago = pago;
    }

    public static Saida NovaFatura(DateTime data, double valor, string descricao, bool pago)
    {
        return new Saida(data, valor, descricao, true, pago);
    }
}