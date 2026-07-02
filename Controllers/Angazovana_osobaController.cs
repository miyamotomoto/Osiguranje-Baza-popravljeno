using DatabaseAccses.DTOs;
using DatabaseAccses;
using Microsoft.AspNetCore.Mvc;

namespace Osiguranje_Baza_popravljeno.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Angazovana_osobaController:ControllerBase
    {
        [HttpGet]
        [Route("PrikaziAngazovanu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAngazovanu(int id_klijenta)
        {
            try
            {
                return new JsonResult(DataProvider.vratiAngazovanu(id_klijenta));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DodajAngazovanu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DodajKlijenta([FromBody] Angazovana_osobaView klijent)
        {
            var Tip_klijenta = new HashSet<string>
            {
                "Agent",
                "Lekar_konsultant",
                "Pravnik",
                "Procenitelj",
            };


            try
            {
                if (!Tip_klijenta.Contains(klijent.tip_osobe))
                {
                    return BadRequest("Uneli ste nevalidnu klasu!");
                }


                DataProvider.dodajAngazovanu(klijent);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniAngazovanu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PromeniAngazovanu([FromBody] Angazovana_osobaView avatar)
        {
            try
            {
                DataProvider.azurirajAngazovanu(avatar);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("IzbrisiAngazovanu/{idKlijenta}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult IzbrisiAvatara(int idKlijenta)
        {
            try
            {
                DataProvider.obrisiAngazovanu(idKlijenta);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }





    }
}
