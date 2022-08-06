using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Data.DTOs
{
    public  class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }

        public double Price { get; set; }
 
        public string ProductType { get; set; }

        public double Discount { get; set; } = 0;
    }
}
