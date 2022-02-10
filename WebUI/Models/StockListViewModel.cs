using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class StockListViewModel
    {
        public List<StockListDto> stocks { get; set; }
    }
}
