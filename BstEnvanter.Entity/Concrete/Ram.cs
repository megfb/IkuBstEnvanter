using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.Entity.Concrete
{
    public class Ram:IEntity
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Ram name cannot be null")]

        public string name { get; set; }
        public List<Product> product { get; set; }
    }
}