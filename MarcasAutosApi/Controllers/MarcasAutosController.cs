using MarcasAutosApi.Models.Dto;
using MarcasAutosApi.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarcasAutosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasAutosController : ControllerBase
    {
        private readonly IMarcaAutoRepository _marcaAutoRepository;

        public MarcasAutosController(IMarcaAutoRepository marcaAutoRepository)
        {
            _marcaAutoRepository = marcaAutoRepository;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var response = await _marcaAutoRepository.Delete(id);

                if (response == null) return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var marcasAutos = await _marcaAutoRepository.Get();

                return Ok(marcasAutos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var marcaAuto = await _marcaAutoRepository.Get(id);

                if (marcaAuto == null) return NotFound();

                return Ok(marcaAuto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarcaAutoDto marcaAutoDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var marcaAuto = await _marcaAutoRepository.Create(marcaAutoDto);

                    if (marcaAuto == null) return BadRequest("La marca ya existe!");

                    return CreatedAtAction(nameof(Get), new { id = marcaAuto.Id }, marcaAuto);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else 
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MarcaAutoDto marcaAutoDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var marcaAuto = await _marcaAutoRepository.Update(marcaAutoDto);

                    if (marcaAuto == null) return BadRequest("No se encontro la marca o el nombre de la marca ya existe!");

                    return CreatedAtAction(nameof(Get), new { id = marcaAuto.Id }, marcaAuto);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
