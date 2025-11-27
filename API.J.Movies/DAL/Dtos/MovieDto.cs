using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la pelicula es obligatorio")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required(ErrorMessage = "La duracion de la pelicula es obligatorio")]
        public int Duration { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "La clasificacion de la pelicula es obligatorio")]
        [MaxLength(10, ErrorMessage = "El numero maximo de caracteres es de 10.")]
        public string Clasification { get; set; }

    }
}
