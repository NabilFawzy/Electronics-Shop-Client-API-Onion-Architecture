using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Data.DTOs
{
    public class Pagination
    {
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public List<ProductDto> data { get; set; }
    }
}
