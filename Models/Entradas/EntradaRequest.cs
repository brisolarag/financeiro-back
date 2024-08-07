using System.ComponentModel.DataAnnotations;

namespace financeiro_back.Models.Entradas;

public class EntradaRequest
{
    
    [Required]
    public DateTime Data { get; set; }
    
    [Required]
    public double Valor { get; set; }
    
    [Required]
    [MaxLength(60)]
    public string DeQuem { get; set; } = null!;


    public Entrada? Parse()
    {
        try
        {
            return new Entrada(this.Data, this.Valor, this.DeQuem);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }
}