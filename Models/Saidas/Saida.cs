namespace financeiro_back.Models.Saidas;

public class Saida : Operacao
{
    public string Descricao { get; set; } = null!;
    public bool isFatura { get; set; }

    public static Saida NovaFatura(DateTime data, double valor, string descricao)
    {
        return new Saida
        {
            Id = Guid.NewGuid(),
            Data = data,
            Valor = valor,
            Descricao = descricao,
            isFatura = true
        };
    }
}