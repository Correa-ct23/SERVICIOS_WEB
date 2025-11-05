using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        //PROPIEDADES | SE CONVIERTEN EN COLUMNAS DE LAS TABLAS

        [Required]
        public string Name { get; set; }
    }
}
