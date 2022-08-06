using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArch.Data.DTOs
{
    public class ProductFilterDto
    {

        private const int maxPageSize = 5;
        public int? ProductTypeId { get; set; }
        public int pageIndex { get; set; } = 1;
        private int _pageSize { get; set; } = 5;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value>maxPageSize?maxPageSize:value; }
        }
  
    }
}
