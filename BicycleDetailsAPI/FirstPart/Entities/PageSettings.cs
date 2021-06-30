using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

#nullable enable

namespace LowerLayer
{
    public class PageSettings
    {

        public int PageNumber { get; set; } = 1;
        private int pageSize = 5;
        public int PageSize {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > 20) ? 20 : value; 
            }        
        }
        public string? FilterString { get; set; }
        public string? SortOrder { get; set; }
    }
}
