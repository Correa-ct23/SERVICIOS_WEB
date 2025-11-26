using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Dtos
{
    public class MovieCreateDto
    {
        [Required(ErrorMessage = "El nombre de la pelicula es obligatorio")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
