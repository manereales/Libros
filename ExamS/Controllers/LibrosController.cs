using AutoMapper;
using ExamS.DTOs;
using ExamS.Entidades;
using ExamS.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamS.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LibrosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroDTO>>> Get()
        {
            var libros = await context.Libros.ToListAsync();

            var dtos = mapper.Map<List<LibroDTO>>(libros);

            return dtos;

        }

        [HttpGet("{id}", Name = "obtenerLibro")]
        public async Task<ActionResult<LibroDTO>> Get(int id)
        {
            var libros = await context.Libros.FirstOrDefaultAsync(x => x.Id == id);

            if (libros == null)
                return NotFound();

            return mapper.Map<LibroDTO>(libros);
        }

        [HttpPost]
        public async Task<ActionResult> PostLibro([FromForm]LibroCreacionDTO libroCreacionDTO)
        {
            var entidades = mapper.Map<Libros>(libroCreacionDTO);

            //var cantidad = libroCreacionDTO.Cantidad;

            //if (cantidad > 0)
            //{
            //    cantidad--;
            //}
            context.Add(entidades);
            //entidades.Cantidad = cantidad;
            await context.SaveChangesAsync();

            var dtos = mapper.Map<LibroDTO>(entidades);

            return CreatedAtRoute("obtenerLibro", new { id = entidades.Id}, dtos);
        }





        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromForm] LibroCreacionDTO libroCreacionDTO)
        {


            var existe = await context.Libros.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            var libros = mapper.Map<Libros>(libroCreacionDTO);
            libros.Id = id;


            context.Update(libros);
            await context.SaveChangesAsync();

            return NoContent();

        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Libros.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Libros() { Id = id});
            await context.SaveChangesAsync();

            return NoContent();


        }

    }
}
