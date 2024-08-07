using financeiro_back.Models.Saidas;
using financeiro_back.Repositories.SaidasRepository;
using Microsoft.AspNetCore.Http.HttpResults;
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
}