namespace financeiro_back.Models.Saidas;

public class Saida : Operacao
{
    public string Descricao { get; set; } 
    public bool isFatura { get; set; }
    public DateTime? Pagamento { get; set; }

    public Saida() { }
    public Saida(DateTime data, double valor, string desc, bool isFatura, DateTime? pagamento) 
        : base(data, valor)
    {
        this.isFatura = isFatura;
        
        if (this.isFatura)
            this.Descricao = $"Fatura - {desc}";
        else
            this.Descricao = desc;
        
        if (pagamento.HasValue)
            this.Pagamento = pagamento;
    }

    public static Saida NovaFatura(DateTime data, double valor, string descricao, DateTime pagamento)
    {
        return new Saida(data, valor, descricao, true, pagamento);
    }
}