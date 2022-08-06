using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Data.Entities
{
    public class AnnonymsUser
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public Guid productId { get; set; }
        public int quantity { get; set; }

        public double Price { get; set; }
    }
}
