using System;
using System.ComponentModel.DataAnnotations;

namespace LowerLayer
{
    public class BicycleDetail
    {
        [Key]
        public int Id { get;set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Brand { get; set; }
        public string Producer { get; set; }
    }
}
