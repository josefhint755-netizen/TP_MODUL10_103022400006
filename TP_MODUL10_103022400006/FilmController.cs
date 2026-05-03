using Microsoft.AspNetCore.Mvc;
using TP_MODUL10_103022400006.FilmAPI.Models;

namespace FilmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private static List<Film> films = new List<Film>
        {
            new Film { Id = 1, Judul = "Inception", Sutradara = "Christopher Nolan", Tahun = "2010", Genre = "Sci-Fi", Rating = "9.0" },
            new Film { Id = 2, Judul = "Interstellar", Sutradara = "Christopher Nolan", Tahun = "2014", Genre = "Sci-Fi", Rating = "8.7" },
            new Film { Id = 3, Judul = "Parasite", Sutradara = "Bong Joon-ho", Tahun = "2019", Genre = "Thriller", Rating = "8.6" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Film>> Get()
        {
            return Ok(films);
        }

        [HttpGet("{id}")]
        public ActionResult<Film> Get(int id)
        {
            var film = films.FirstOrDefault(f => f.Id == id);
            if (film == null)
                return NotFound();
            return Ok(film);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return CreatedAtAction(nameof(Get), new { id = film.Id }, film);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(f => f.Id == id);
            if (film == null)
                return NotFound();
            films.Remove(film);
            return NoContent();
        }
    }
}