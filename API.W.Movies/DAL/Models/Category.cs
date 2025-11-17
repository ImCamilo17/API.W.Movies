using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DAL.Models
{
    public class Category: AuditBase
    {
        [Required] //indica que el campo es obligatorio
        public string Name { get; set; }
    }
}
