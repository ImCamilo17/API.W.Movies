using System.ComponentModel.DataAnnotations;


namespace API.W.Movies.DAL.Models
{
    public class AuditBase
    {
        [Key] //Indica que el campo es clave primaria
        public virtual int Id { get; set; }
        public virtual int CreteDate { get; set; }
        public virtual int ModifiedDate { get; set; }
    }
}
