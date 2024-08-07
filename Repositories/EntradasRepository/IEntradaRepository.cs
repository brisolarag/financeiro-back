using financeiro_back.Models.Entradas;

namespace financeiro_back.Repositories.EntradasRepository;

public interface IEntradaRepository
{
    Task<List<Entrada>> GetAsync();
    Task<Entrada?> GetAsync(Guid id);
    Task<Entrada> DeleteAsync(Guid id);
    Task<Entrada> CreateAsync(EntradaRequest request);
    Task<Entrada> EditAsync(Guid id, EntradaRequestEdit request);
}