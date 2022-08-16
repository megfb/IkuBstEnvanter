using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class MoveToPersonelViewModel
    {

        public Status status { get; set; }
        public List<Personel> personel { get; set; }
        public List<Campus> campus { get; set; }
    }
}