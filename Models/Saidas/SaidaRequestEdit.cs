using System.ComponentModel.DataAnnotations;

namespace financeiro_back.Models.Saidas;

public class SaidaRequestEdit
{
    public DateTime? Data { get; set; }
    
    public double? Valor { get; set; }
    
    [MaxLength(100)]
    public string? Descricao { get; set; }

    public bool? isFatura { get; set; }
}