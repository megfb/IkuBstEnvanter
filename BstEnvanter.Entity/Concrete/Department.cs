using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.Entity.Concrete
{
    public class Department:IEntity
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Brand Department cannot be null")]

        public string name { get; set; }
        public ICollection<Personel> personel { get; set; }
        public ICollection<Common> common { get; set; }
    }
}