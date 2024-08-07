using financeiro_back.Context;
using financeiro_back.Erros;
using financeiro_back.Models.Entradas;
using financeiro_back.Models.Saidas;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace financeiro_back.Repositories.EntradasRepository;

public class EntradaRepository : IEntradaRepository
{
    private readonly FinanceiroContext _context;

    public EntradaRepository(FinanceiroContext context) => this._context = context;
    
    
    public async Task<List<Entrada>> GetAsync()
    {
        return await _context.Entradas.ToListAsync();
    }

    public Task<Entrada?> GetAsync(Guid id)
    {
        try
        {
            var entrada = _context.Entradas.SingleOrDefaultAsync(saida => saida.Id == id);
            return entrada;
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro inesperado", ex);
        }
    }

    public async Task<Entrada> CreateAsync(EntradaRequest request)
    {
        var newEntrada = request.Parse();
        if (newEntrada is null)
            throw new DtoException("Não foi possivel criar a nova entrada");

        try
        {
            _context.Entradas.Add(newEntrada);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new DbUpdateException("Não foi possivel salvar no banco", ex);
        }

        return newEntrada;
    }

    public async Task<Entrada> DeleteAsync(Guid id)
    {
        var deletar = await GetAsync(id);
        VerificarSeEntidadeNaoEncontrada(deletar);

        _context.Entradas.Remove(deletar!);
        await _context.SaveChangesAsync();
        return deletar!;
    }


    public async Task<Entrada> EditAsync(Guid id, EntradaRequestEdit request)
    {
        var toEdit = await GetAsync(id);
        VerificarSeEntidadeNaoEncontrada(toEdit);
        AlteraSeModificado(toEdit!, request);
        
        try
        {
            _context.Entradas.Update(toEdit!);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        { throw new DbUpdateException("Não foi possivel modificar a entidade", ex); }
        
        
        return toEdit!;
    }


    // verificadores:
    private void VerificarSeEntidadeNaoEncontrada(Entrada? entidade)
    {
        if (entidade == null)
        {
            throw new NotFoundException("Não foi possível encontrar a saída.");
        }
    }
    private void AlteraSeModificado(Entrada entidade, EntradaRequestEdit request)
    {
        try
        {
            if (request.Data.HasValue)
                entidade.Data = request.Data.Value;

            if (request.Valor.HasValue)
                entidade.Valor = request.Valor.Value;

            if (!string.IsNullOrEmpty(request.DeQuem))
                entidade.DeQuem = request.DeQuem;
            
        }
        catch (Exception ex)
        {
            throw new DbUpdateException("Não foi possivel modificar a entidade", ex);
        }
    }
}