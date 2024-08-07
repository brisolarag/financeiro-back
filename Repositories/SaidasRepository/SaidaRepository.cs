using financeiro_back.Context;
using financeiro_back.Erros;
using financeiro_back.Models.Saidas;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace financeiro_back.Repositories.SaidasRepository;

public class SaidaRepository : ISaidaRepository
{
    private readonly FinanceiroContext _context;
    private NotFoundException saidaNaoEncontrada = new NotFoundException("Não foi possivel encontrar a saida");

    public SaidaRepository(FinanceiroContext context) => this._context = context;
    
    
    public async Task<List<Saida>> GetAsync()
    {
        return await _context.Saidas.ToListAsync();
    }

    public Task<Saida?> GetAsync(Guid id)
    {
        try
        {
            var saida = _context.Saidas.SingleOrDefaultAsync(saida => saida.Id == id);
            return saida;
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro inesperado", ex);
        }
    }

    public async Task<Saida> CreateAsync(SaidaRequest request)
    {
        var newSaida = request.Parse();
        if (newSaida is null)
            throw new DtoException("Não foi possivel criar a nova saida");

        try
        {
            _context.Saidas.Add(newSaida);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new DbUpdateException("Não foi possivel salvar no banco", ex);
        }

        return newSaida;
    }

    public Task<Saida> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }


    public async Task<Saida> EditAsync(Guid id, SaidaRequestEdit request)
    {
        var toEdit = await GetAsync(id);
        if (toEdit is null)
            throw saidaNaoEncontrada;
        
        AlteraSeModificado(toEdit, request);

        try
        {
            _context.Saidas.Update(toEdit);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        { throw new DbUpdateException("Não foi possivel modificar a entidade", ex); }
        
        
        return toEdit;
    }


    private void AlteraSeModificado(Saida entidade, SaidaRequestEdit request)
    {
        try
        {
            if (request.Data.HasValue)
                entidade.Data = request.Data.Value;

            if (request.Valor.HasValue)
                entidade.Valor = request.Valor.Value;

            if (!string.IsNullOrEmpty(request.Descricao))
                entidade.Descricao = request.Descricao;

            if (request.isFatura.HasValue)
                entidade.isFatura = request.isFatura.Value;
        }
        catch (Exception ex)
        {
            throw new DbUpdateException("Não foi possivel modificar a entidade", ex);
        }
    }
}