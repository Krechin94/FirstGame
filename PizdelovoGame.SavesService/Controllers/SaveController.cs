using Microsoft.AspNetCore.Mvc;
using PizdelovoGame.SavesService.Exceptions;
using PizdelovoGame.SavesService.Model;
using PizdelovoGame.SavesService.Service;

namespace PizdelovoGame.SavesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaveController : ControllerBase
    {
        private readonly FileSaveService _fileSaveService;

        public SaveController(FileSaveService fileSaveService)
        {
            _fileSaveService = fileSaveService;
        }

        [HttpPut]
        public async Task<ActionResult<PlayerDto>> Player([FromBody] PlayerDto player)
        {
            if (player == null)
                return BadRequest("Отсутствует информация об игроке.");

            if(!ModelState.IsValid)
                return BadRequest("Недостаточно информации об игроке. Возможно были нарушены лимиты" +
                    " возможных значений. Проверьте правильность запроса.");

            try
            {
                await _fileSaveService.Save(player);
                return Ok(player);
            }
            catch(PlayerNotCreatedException pnce)
            {
                return StatusCode(504, pnce.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<PlayerDto>> Player([FromBody] string name)
        {
            if (name == null)
                return BadRequest("Укажите имя игрока.");

            if (!ModelState.IsValid)
                return BadRequest("Недостаточно информации об игроке. Возможно были нарушены лимиты" +
                    " возможных значений. Проверьте правильность запроса.");

            try
            {
                return Ok(await _fileSaveService.Download(name));
            }
            catch(PlayerReadException pre)
            {
                return BadRequest(pre.Message);
            }
            catch(NoSuchPlayerException nspe)
            {
                return NotFound(nspe.Message);
            }
        }
    }
}