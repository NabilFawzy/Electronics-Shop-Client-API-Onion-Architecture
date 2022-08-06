using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Data.DTOs
{
    public class AnnonymsUserDto
    {
        public string Email { get; set; }

        public Guid productId { get; set; }
        public int quantity { get; set; }

        public double Price { get; set; }
    }
}
