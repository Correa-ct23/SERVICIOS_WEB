using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Models
{
    public class AuditBase
    {
        //DECORATOR
        [Key] //PRIMARY KEY
        public int Id { get; set; } //PK DE TODAS LAS TABLAS

        public DateTime CreatedDate { get; set; } //ME SIRVE PARA GUARDAR LA FECHA DE CREACION

        public DateTime? ModifiedDate { get; set; } //ME SIRVE PARA GUARDAR LA FECHA DE MODIFICACION
    }
}
