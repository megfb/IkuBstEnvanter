using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.Entity.Concrete
{
    public class Model:IEntity
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Model name cannot be null")]

        public string name { get; set; }
        public ICollection<Product> product { get; set; }
    }
}