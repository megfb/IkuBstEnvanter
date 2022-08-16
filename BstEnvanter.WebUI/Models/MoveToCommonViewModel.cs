using BstEnvanter.Entity.Concrete;

namespace BstEnvanter.WebUI.Models
{
    public class MoveToCommonViewModel
    {
        public MoveToCommonViewModel()
        {
        }

        public Status status { get; set; }
        public Common common { get; set; }
        public List<CLocation> clocation { get; set; }
        public List<Department> department { get; set; }
        public List<Campus> campus { get; internal set; }
    }
}