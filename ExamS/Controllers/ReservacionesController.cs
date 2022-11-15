using AutoMapper;
using ExamS.DTOs;
using ExamS.Entidades;
using ExamS.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamS.Controllers
{
    [ApiController]
    [Route("api/reserv")]
    public class ReservacionesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ReservacionesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reservacion>>> Get()
        {
            var reservaciones = await context.Reservaciones.ToListAsync();

            var dtos = mapper.Map<List<Reservacion>>(reservaciones);

            return dtos;
        }


        [HttpGet("{id}", Name = "obtenerReservacion")]
        public async Task<ActionResult<List<Reservacion>>> Get(int id)
        {


            var reservaciones = await context.Reservaciones.ToListAsync();

            var dtos = mapper.Map<List<Reservacion>>(reservaciones);

            return dtos;
        }


        [HttpPost("{id}")]
        public async Task<ActionResult> Post(int id, [FromForm] ReservacionCreacionDTO reservacionCreacionDTO)
        {
            var libros = await context.Libros.FirstOrDefaultAsync(x => x.Id == id);

            if (libros == null)
            {
                return NotFound("libro no encontrado");
            }
            
            var reservacion = mapper.Map<Reservacion>(reservacionCreacionDTO);
               

            context.Add(reservacion);
            libros.Cantidad --;
            
            await context.SaveChangesAsync();

            var dtos = mapper.Map<ReservacionDTO>(reservacion);



            return CreatedAtRoute("obtenerReservacion", new { id = reservacion.Id }, dtos);
        }




    }
}
