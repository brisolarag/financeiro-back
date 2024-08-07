namespace financeiro_back.Models.Saidas;

public class Saida : Operacao
{
    public string Descricao { get; set; } 
    public bool isFatura { get; set; }

    public Saida() { }
    public Saida(DateTime data, double valor, string desc, bool isFatura) 
        : base(data, valor)
    {
        this.Descricao = desc;
        this.isFatura = isFatura;
    }

    public static Saida NovaFatura(DateTime data, double valor, string descricao)
    {
        return new Saida(data, valor, descricao, true);
    }
}