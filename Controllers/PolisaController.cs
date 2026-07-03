using DatabaseAccses.DTOs;
using DatabaseAccses;
using Microsoft.AspNetCore.Mvc;

namespace Osiguranje_Baza_popravljeno.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolisaController:ControllerBase
    {
        [HttpGet]
        [Route("PrikaziPolisu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPolisu(int id_klijenta)
        {
            try
            {
                return new JsonResult(DataProvider.vratiPolisu(id_klijenta));
            }
            catch (Exception ex)
            {
                throw;
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DodajPolisu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DodajPolisu([FromBody] PolisaView klijent)
        {
            var Tip_klijenta = new HashSet<string>
            {
               "Specijalizovano_osiguranje",
                "Osiguranje_od_odgovornosti",
                "Auto_osiguranje",
                "Zivotno_osiguranje",
                 "Zdravstveno_osiguranje",
                "Imovinsko_osiguranje",
                "Poljoprivredno_osiguranje",
                "Putno_osiguranje"
            };


            try
            {
                if (!Tip_klijenta.Contains(klijent.tip_polise))
                {
                    return BadRequest("Uneli ste nevalidnu klasu!");
                }


                DataProvider.dodajPolisu(klijent);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniPolisu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PromeniStetu([FromBody] PolisaView avatar)
        {
            try
            {
                DataProvider.azurirajPolisu(avatar);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("IzbrisiPolisu/{idPolise}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult IzbrisiAvatara(int idPolise)
        {
            try
            {
                DataProvider.obrisiAngazovanu(idPolise);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
