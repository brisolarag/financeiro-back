using financeiro_back.Context;
using financeiro_back.Erros;
using financeiro_back.Models.Saidas;
using Microsoft.EntityFrameworkCore;

namespace financeiro_back.Repositories.SaidasRepository;

public class SaidaRepository : ISaidaRepository
{
    private readonly FinanceiroContext _context;

    public SaidaRepository(FinanceiroContext context) => this._context = context;
    
    
    public async Task<List<Saida>> GetAsync
    (Guid? id, string? descricao, bool? is_fatura, bool? pago, DateTime? referencia)
    {
        var query = _context.Saidas.AsQueryable();
        // se tiver id na pesquisa ignora o resto e pesquisa o id
        query = Verificadores(query, descricao, is_fatura, pago, referencia);

        return await query.ToListAsync();
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

    public async Task<Saida> DeleteAsync(Guid id)
    {
        var deletar = await GetAsync(id);
        VerificarSeEntidadeNaoEncontrada(deletar);

        _context.Saidas.Remove(deletar!);
        await _context.SaveChangesAsync();
        return deletar!;
    }


    public async Task<Saida> EditAsync(Guid id, SaidaRequestEdit request)
    {
        var toEdit = await GetAsync(id);
        VerificarSeEntidadeNaoEncontrada(toEdit);
        AlteraSeModificado(toEdit!, request);
        
        try
        {
            _context.Saidas.Update(toEdit!);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        { throw new DbUpdateException("Não foi possivel modificar a entidade", ex); }
        
        
        return toEdit!;
    }
    
    
    
    private Task<Saida?> GetAsync(Guid id)
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
    
    private IQueryable<Saida> Verificadores(IQueryable<Saida> query, string? descricao, bool? is_fatura, bool? pago, DateTime? referencia)
    {
        
        // filtra descricao
        if (!(string.IsNullOrEmpty(descricao)))
            query = query.Where(saida => saida.Descricao.Contains(descricao));
        
        // filtra fatura
        if (is_fatura.HasValue)
            query = query.Where(saida => saida.isFatura == is_fatura);

        // filtra se pago
        if (pago.HasValue)
            query = query.Where(saida => saida.Pagamento != null);


        if (referencia.HasValue)
        {
            query = query
                .Where(saida =>
                    saida.Descricao.ToLower().Contains("nubank")
                        ? saida.Data.Month == referencia.Value.AddMonths(1).Month
                        : saida.Data.Month == referencia.Value.Month)
                .Where(saida => saida.Data.Year == referencia.Value.Year);
        }

        return query;
    }
    
    // verificadores:
    private void VerificarSeEntidadeNaoEncontrada(Saida? entidade)
    {
        if (entidade == null)
        {
            throw new NotFoundException("Não foi possível encontrar a saída.");
        }
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
            
            if (request.Pagamento.HasValue)
                entidade.Pagamento = request.Pagamento.Value;
        }
        catch (Exception ex)
        {
            throw new DbUpdateException("Não foi possivel modificar a entidade", ex);
        }
    }

}
