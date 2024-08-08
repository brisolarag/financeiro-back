using System.ComponentModel.DataAnnotations;

namespace financeiro_back.Models.Saidas;
public class SaidaRequest
{
    
    [Required]
    public DateTime Data { get; set; }
    
    [Required]
    public double Valor { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Descricao { get; set; } = null!;

    [Required]
    public bool isFatura { get; set; }

    [Required]
    public bool Pago { get; set; }


    public Saida? Parse()
    {
        try
        {
            return new Saida(this.Data, this.Valor, this.Descricao, this.isFatura, this.Pago);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }
}