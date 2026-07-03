using DatabaseAccses.DTOs;
using DatabaseAccses;
using Microsoft.AspNetCore.Mvc;

namespace Osiguranje_Baza_popravljeno.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Faze_obrade_steteController:ControllerBase
    {
        [HttpGet]
        [Route("PrikaziFazu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetFazu(int id_stete)
        {
            try
            {
                return new JsonResult(DataProvider.vratiFazu(id_stete));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DodajFazu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DodajFazu([FromBody] Faza_obrade_steteView klijent)
        {
          

            try
            {
                DataProvider.dodajFazu(klijent);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniFazu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PromeniFazu([FromBody] Faza_obrade_steteView avatar)
        {
            try
            {
                DataProvider.azurirajFaze(avatar);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("IzbrisiFazu/{redni_broj_stete}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult IzbrisiFazu(int redni_broj_stete)
        {
            try
            {
                DataProvider.obrisiFazu(redni_broj_stete);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
