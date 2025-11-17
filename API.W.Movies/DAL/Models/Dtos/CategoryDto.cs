using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DAL.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la categoria es obligatoria.")]
        [MaxLength(100, ErrorMessage = "El nombre de la categoria no puede exceder los 100 caracteres.")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
