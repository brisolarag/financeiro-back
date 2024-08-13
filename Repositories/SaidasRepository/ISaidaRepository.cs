using financeiro_back.Models.Saidas;

namespace financeiro_back.Repositories.SaidasRepository;

public interface ISaidaRepository
{
    Task<List<Saida>> GetAsync(Guid? id, string? descricao, bool? is_fatura, bool? pago, DateTime? referencia);
    Task<Saida> CreateAsync(SaidaRequest request);
    Task<Saida> DeleteAsync(Guid id);
    Task<Saida> EditAsync(Guid id, SaidaRequestEdit request);
}