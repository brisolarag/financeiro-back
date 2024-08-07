using financeiro_back.Models.Saidas;
using financeiro_back.Repositories.SaidasRepository;
using Microsoft.AspNetCore.Mvc;

namespace financeiro_back.Controllers;

[ApiController]
[Route("[controller]")]
public class SaidaController : ControllerBase
{
    private readonly ISaidaRepository _service;

    public SaidaController(ISaidaRepository service)
    {
        this._service = service;
    }

    #region GET: /saida => retorna todos
    [HttpGet]
    public async Task<ActionResult<List<Saida>>> Get()
    {
        try
        {
            var saidas = await _service.GetAsync();
            return Ok(new
            {
                error = false,
                data = saidas
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
    
    #region GET: /saida/{id} => retorna saida com id
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<List<Saida?>>> Get(Guid id)
    {
        try
        {
            var saida = await _service.GetAsync(id);
            if (saida is null)
                return NotFound(new
                {
                    error = true,
                    msg = "Nenhuma saida com esse id encontrada"
                });
                
            return Ok(new
            {
                error = false,
                data = saida
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
    
    #region POST: /saida => criar nova saida
    [HttpPost]
    public async Task<ActionResult<Saida>> Create([FromBody] SaidaRequest request)
    {
        try
        {
            var newSaida = await _service.CreateAsync(request);
            return Created(newSaida.Id.ToString(), new
            {
                error = false,
                msg = "Nova saida criada com sucesso",
                data = newSaida
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

    #region PUT: /saida => editar saida
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Saida>> Edit(Guid id, SaidaRequestEdit request)
    {
        try
        {
            var saidaEdit = await _service.EditAsync(id, request);
            return Ok(new
            {
                error = false,
                msg = "Saida editada com sucesso",
                data = saidaEdit
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
    
    #region DELETE: /saida/{id} => editar saida
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Saida>> Deletar(Guid id)
    {
        try
        {
            var deletar = await _service.DeleteAsync(id);
            return Ok(new
            {
                error = false,
                msg = "Saida deletada com sucesso",
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