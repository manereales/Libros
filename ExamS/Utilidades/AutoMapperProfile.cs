using AutoMapper;
using ExamS.DTOs;
using ExamS.Entidades;

namespace ExamS.Utilidades
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Libros, LibroDTO>();
            CreateMap<LibroCreacionDTO, Libros>();

            CreateMap<Usuarios,UsuariosDTO>()/*.ForMember(libro => libro.libros, opciones => opciones.MapFrom())*/;
            CreateMap<UsuarioCreacionDTO, Usuarios>()/*.ForMember(libros => libros.Reservacion, opciones => opciones.MapFrom(MapLibroCreacionDTO))*/;

            CreateMap<Reservacion, ReservacionDTO>();
            CreateMap<ReservacionCreacionDTO, Reservacion>();

        }



        private List<Reservacion> MapLibroCreacionDTO(UsuarioCreacionDTO usuarioCreacionDTO, Usuarios usuarios)
        {
            var resultado = new List<Reservacion>();

            if (usuarioCreacionDTO.Ids == null)
            {
                return resultado;
            }
            foreach (var ids in usuarioCreacionDTO.Ids)
            {
                resultado.Add(new Reservacion()
                {
                    UsuariosId = ids
                });
            }

            return resultado;
        }

    }
}
