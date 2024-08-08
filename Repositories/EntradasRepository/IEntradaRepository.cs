using financeiro_back.Models.Entradas;

namespace financeiro_back.Repositories.EntradasRepository;

public interface IEntradaRepository
{
    Task<List<Entrada>> GetAsync(Guid? id, string? de_quem);
    Task<Entrada> DeleteAsync(Guid id);
    Task<Entrada> CreateAsync(EntradaRequest request);
    Task<Entrada> EditAsync(Guid id, EntradaRequestEdit request);
}