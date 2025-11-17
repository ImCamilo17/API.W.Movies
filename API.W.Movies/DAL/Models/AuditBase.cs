using System.ComponentModel.DataAnnotations;


namespace API.W.Movies.DAL.Models
{
    public class AuditBase
    {
        [Key] //Indica que el campo es clave primaria
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}
