using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.Entity.Concrete
{
    public class HardDrive:IEntity
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Hard Drive name cannot be null")]

        public string name { get; set; }
        public List<Product> product { get; set; }
    }
}