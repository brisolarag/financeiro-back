using financeiro_back.Models.Entradas;
using financeiro_back.Repositories.EntradasRepository;
using Microsoft.AspNetCore.Mvc;

namespace financeiro_back.Controllers;
[ApiController]
[Route("[controller]")]
public class EntradaController : ControllerBase
{
    private readonly IEntradaRepository _service;

    public EntradaController(IEntradaRepository service)
    {
        this._service = service;
    }

    #region GET: /entrada => retorna todos
    [HttpGet]
    public async Task<ActionResult<List<Entrada>>> Get()
    {
        try
        {
            var entradas = await _service.GetAsync();
            return Ok(new
            {
                error = false,
                data = entradas
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = true,
                msg = ex.Message
            });
        }
    }
    #endregion
    
    #region GET: /entrada/{id} => retorna entrada com id
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<List<Entrada?>>> Get(Guid id)
    {
        try
        {
            var entrada = await _service.GetAsync(id);
            if (entrada is null)
                return NotFound(new
                {
                    error = true,
                    msg = "Nenhuma entrada com esse id encontrada"
                });
                
            return Ok(new
            {
                error = false,
                data = entrada
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = true,
                msg = ex.Message
            });
        }
    }
    #endregion
    
    #region POST: /entrada => criar nova entrada
    [HttpPost]
    public async Task<ActionResult<Entrada>> Create([FromBody] EntradaRequest request)
    {
        try
        {
            var newEntrada = await _service.CreateAsync(request);
            return Created(newEntrada.Id.ToString(), new
            {
                error = false,
                msg = "Nova entrada criada com sucesso",
                data = newEntrada
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = true,
                msg = ex.Message
            });
        }
    }
    #endregion

    #region PUT: /entrada => editar entrada
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Entrada>> Edit(Guid id, EntradaRequestEdit request)
    {
        try
        {
            var entradaEdit = await _service.EditAsync(id, request);
            return Ok(new
            {
                error = false,
                msg = "Entrada editada com sucesso",
                data = entradaEdit
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = true,
                msg = ex.Message
            });
        }
    }
    #endregion
    
    #region DELETE: /entrada/{id} => remover entrada
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Entrada>> Deletar(Guid id)
    {
        try
        {
            var deletar = await _service.DeleteAsync(id);
            return Ok(new
            {
                error = false,
                msg = "Entrada deletada com sucesso",
                data = deletar
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                error = true,
                msg = ex.Message
            });
        }
    }
    #endregion
}