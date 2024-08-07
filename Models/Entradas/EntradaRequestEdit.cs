using System.ComponentModel.DataAnnotations;

namespace financeiro_back.Models.Entradas;

public class EntradaRequestEdit
{
    public DateTime? Data { get; set; }
    public double? Valor { get; set; }
    [MaxLength(60)]
    public string? DeQuem { get; set; }
}