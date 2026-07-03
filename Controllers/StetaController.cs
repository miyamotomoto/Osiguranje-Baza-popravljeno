using DatabaseAccses.DTOs;
using DatabaseAccses;
using Microsoft.AspNetCore.Mvc;

namespace Osiguranje_Baza_popravljeno.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StetaController:ControllerBase
    {
        [HttpGet]
        [Route("PrikaziStetu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetStetu(int id_klijenta)
        {
            try
            {
                return new JsonResult(DataProvider.vratiStetu(id_klijenta));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DodajStetu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DodajStetu([FromBody] StetaView klijent)
        {
            var Tip_klijenta = new HashSet<string>
            {
                "Auto_steta",
                "Imovinska_steta",
                "Zdravstvena_steta",
            };


            try
            {
                if (!Tip_klijenta.Contains(klijent.vrsta_stete))
                {
                    return BadRequest("Uneli ste nevalidnu klasu!");
                }


                DataProvider.dodajStetu(klijent);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniStetu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PromeniStetu([FromBody] StetaView avatar)
        {
            try
            {
                DataProvider.azurirajStetu(avatar);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("IzbrisiStetu/{idStete}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult IzbrisiAvatara(int idStete)
        {
            try
            {
                DataProvider.obrisiAngazovanu(idStete);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
