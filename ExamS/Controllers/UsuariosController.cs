using AutoMapper;
using ExamS.DTOs;
using ExamS.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamS.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ILogger<UsuariosController> logger;

        public UsuariosController(ApplicationDbContext context, IMapper mapper, ILogger<UsuariosController> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }



        [HttpGet]
        public async Task<ActionResult<List<UsuariosDTO>>> Get()
        {
            try
            {
                var usuarios = await context.Usuarios.ToListAsync();

                var dtos = mapper.Map<List<UsuariosDTO>>(usuarios);

                return dtos;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           

        }



        [HttpGet("{id}", Name = "obtenerUsuario")]
        public async Task<ActionResult<UsuariosDTO>> Get(int id)
        {

            try
            {
                logger.LogInformation("Este es un mensaje de información");

                var usuarios = await context.Usuarios
                    //.Include(x => x.Reservacion)
                    //.ThenInclude(x => x.Libros)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (usuarios == null)
                    return NotFound();

                return mapper.Map<UsuariosDTO>(usuarios);
            }
            //las excepciones son errores en tiempo de ejecución del programa que escapan al control del programador
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }






        [HttpPost]
        public async Task<ActionResult> Post([FromForm] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            try
            {
                var entidades = mapper.Map<Usuarios>(usuarioCreacionDTO);

                context.Add(entidades);

                await context.SaveChangesAsync();

                var dtos = mapper.Map<UsuariosDTO>(entidades);

                return CreatedAtRoute("obtenerLibro", new { id = entidades.Id }, dtos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            try
            {
                var existe = await context.Libros.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

                var usuarios = mapper.Map<Usuarios>(usuarioCreacionDTO);
                usuarios.Id = id;


                context.Update(usuarios);
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            

        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
                if (!existe)
                {
                    return NotFound();
                }

                context.Remove(new Usuarios() { Id = id });
                await context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            


        }

    }
}
