using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Models
{
    public class Movie : AuditBase
    {
        //PROPIEDADES | SE CONVIERTEN EN COLUMNAS DE LAS TABLAS

        [Required]
        public string Name { get; set; }

        [Required]
        public string Duration { get; set; }

        public string Description { get; set; }

        [Required]
        public string Clasification { get; set; }


    }
}
