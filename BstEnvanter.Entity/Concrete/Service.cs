using BstEnvanter.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Entity.Concrete
{
    public class Service:IEntity
    {
        public int id { get; set; }
        public int processNumber { get; set; }
        [Required(ErrorMessage = "Company name cannot be null")]

        public string company { get; set; }
        [Required(ErrorMessage = "Specialist name cannot be null")]

        public string specialist { get; set; }
        [Required(ErrorMessage = "Number cannot be null")]

        public Int64 number { get; set; }
        [Required(ErrorMessage = "Adress cannot be null")]

        public string adress { get; set; }
        [Required(ErrorMessage = "Issue cannot be null")]

        public string issue { get; set; }
        public DateTime dateOfStart { get; set; }
        public DateTime dateOfEnd { get; set; }
        public ICollection<Status> status { get; set; }
    }
}
