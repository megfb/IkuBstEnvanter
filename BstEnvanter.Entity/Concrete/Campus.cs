using BstEnvanter.Entity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BstEnvanter.Entity.Concrete
{
    public class Campus:IEntity
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Campus name cannot be null")]
        public string name { get; set; }
        public ICollection<Status> status { get; set; }

    }
}