using BstEnvanter.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Entity.Concrete
{
    public class Service:IEntity
    {
        public int id { get; set; }
        public int processNumber { get; set; }
        public string company { get; set; }
        public string specialist { get; set; }
        public int number { get; set; }
        public string adress { get; set; }
        public string issue { get; set; }
        public DateTime dateOfStart { get; set; }
        public DateTime dateOfEnd { get; set; }
        public ICollection<Status> status { get; set; }
    }
}
