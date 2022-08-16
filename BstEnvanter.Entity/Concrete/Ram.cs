using BstEnvanter.Entity.Abstract;

namespace BstEnvanter.Entity.Concrete
{
    public class Ram:IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Product> product { get; set; }
    }
}