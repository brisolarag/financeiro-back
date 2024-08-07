using financeiro_back.Models.Saidas;

namespace financeiro_back.Repositories.SaidasRepository;

public interface ISaidaRepository
{
    Task<List<Saida>> GetAsync();
    Task<Saida?> GetAsync(Guid id);
    
    Task<Saida> CreateAsync(SaidaRequest request);
    
    Task<Saida> DeleteAsync(Guid id);

    Task<Saida> EditAsync(Guid id, SaidaRequestEdit request);
}