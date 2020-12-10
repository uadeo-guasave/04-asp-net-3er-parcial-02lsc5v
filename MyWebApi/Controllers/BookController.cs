using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly SqliteDbContext db;

        public BookController(SqliteDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var libros = await db.Books.Take(10).ToListAsync();
            
            if (libros.Count == 0)
            {
                return NotFound();
            }

            return libros;
        }

        // TODO: crear una acción que regrese máximo 20 libros
        //       que inician con alguna letra en especifico
        //       EJ: https://localhost:5001/api/book/byletter/t

        // TODO: crear una acción que regrese máximo 20 libros
        //       de una categoría en específico
        //       EJ: https://localhost:5001/api/book/bycategory/4

        // TODO: crear una acción que regrese máximo 20 libros
        //       filtrado por el nombre de un autor o parte de
        //       https://localhost:5001/api/book/byauthor/jk
    }
}