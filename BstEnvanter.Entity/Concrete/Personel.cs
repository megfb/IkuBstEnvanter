using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.Entity.Concrete
{
    public class Personel : IEntity
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name cannot be null")]
        public string name { get; set; }
        [Required(ErrorMessage = "Surname cannot be null")]

        public string surname { get; set; }
        [Required(ErrorMessage = "Age cannot be null")]

        public int age { get; set; }
        public Sex Sex { get; set; }
        public int ?sexId { get; set; }
        public Department Department { get; set; }
        public int? departmentId { get; set; }
        public CLocation CLocation { get; set; }
        public int? cLocationId { get; set; }
        [Required(ErrorMessage = "E-Mail cannot be null")]

        public string eMail { get; set; }
        public ICollection<Status> status { get; set; }
    }
}