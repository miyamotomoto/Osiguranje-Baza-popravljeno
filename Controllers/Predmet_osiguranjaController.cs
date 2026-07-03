using DatabaseAccses.DTOs;
using DatabaseAccses;
using Microsoft.AspNetCore.Mvc;

namespace Osiguranje_Baza_popravljeno.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Predmet_osiguranjaController:ControllerBase
    {
        [HttpGet]
        [Route("PrikaziPredmet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPredmet(int id_klijenta)
        {
            try
            {
                return new JsonResult(DataProvider.vratiPredmet(id_klijenta));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("DodajPredmet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DodajPredmet([FromBody] Predmet_osiguranjaView klijent)
        {
            var Tip_klijenta = new HashSet<string>
            {
                "Lice",
                "Nekretnina",
                "Pokretna_imovina",
                "Usev",
                "Zivotinja",
                "Odgovornost",
                "Putovanje",
                "Vozilo"
            };


            try
            {
                if (!Tip_klijenta.Contains(klijent.TipPredmeta))
                {
                    return BadRequest("Uneli ste nevalidnu klasu!");
                }


                DataProvider.dodajPredmet(klijent);

                return Ok();
            }
            catch (Exception ex)
            {
       
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniPredmet")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PromeniPredmet([FromBody] Predmet_osiguranjaView avatar)
        {
            try
            {
                DataProvider.azurirajPredmet(avatar);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("IzbrisiPredmet/{idPredmeta}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult IzbrisiPredmet(int idPredmeta)
        {
            try
            {
                DataProvider.obrisiPredmet(idPredmeta);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


    }
}
