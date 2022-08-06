using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Data.Entities
{
    public class ProductSeeder
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
         
        public double Price { get; set; }
        public int ProductTypeId { get; set; }
    }
}
