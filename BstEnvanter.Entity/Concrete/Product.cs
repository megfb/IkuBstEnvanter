using BstEnvanter.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstEnvanter.Entity.Concrete
{
    public class Product : IEntity
    {
        public int id { get; set; }
        public Category Category { get; set; }
        public int? categoryId { get; set; }
        public Brand Brand { get; set; }
        public int? brandId { get; set; }
        public Model Model { get; set; }
        public int? modelId { get; set; }
        [Required(ErrorMessage = "Name cannot be null")]
        public string name { get; set; }
        [Required(ErrorMessage = "Serial number cannot be null")]
        public string serialNo { get; set; }
        [Required(ErrorMessage = "Inventory number cannot be null")]
        public string inventoryNo { get; set; }
        public Cpu Cpu { get; set; }
        public int? cpuId { get; set; }
        public Gpu Gpu { get; set; }
        public int? gpuId { get; set; }
        public Ram Ram { get; set; }
        public int? ramId { get; set; }
        public HardDrive HardDrive { get; set; }
        public int? hardDriveId { get; set; }

        //public string? prop1 { get; set; }
        //public string? prop2 { get; set; }
        //public string? prop3 { get; set; }
        //public string? prop4 { get; set; }
        public ICollection<Status> status { get; set; }



    }
}
