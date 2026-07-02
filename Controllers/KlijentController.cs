using DatabaseAccses;
using DatabaseAccses.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace Osiguranje_Baza_popravljeno.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KlijentController : ControllerBase
    {
        [HttpGet]
        [Route("PrikaziKlijenta")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKlijent(int id_klijenta)
        {
            try
            {
                return new JsonResult(DataProvider.vratiKlijenta(id_klijenta));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DodajKlijent/{Tip_Klijenta}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DodajKlijenta([FromBody] CreateKlijentView klijent, string Tip_Klijenta)
        {
            var Tip_klijenta = new HashSet<string>
            {
                "Fizicko_lice",
                "Javna_institucija",
                "Pravno_lice",

            };


            try
            {
                if (!Tip_klijenta.Contains(Tip_Klijenta))
                {
                    return BadRequest("Uneli ste nevalidnu klasu!");
                }


                DataProvider.dodajKlijenta(klijent,Tip_Klijenta);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniKlijent")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PromeniKlijenta([FromBody] CreateKlijentView avatar)
        {
            try
            {
                DataProvider.azurirajKlijenta(avatar);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("IzbrisiKlijenta/{idKlijenta}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult IzbrisiAvatara(int idKlijenta)
        {
            try
            {
                DataProvider.obrisiKlijenta(idKlijenta);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }




















    }
}
