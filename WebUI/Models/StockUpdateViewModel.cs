using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class StockUpdateViewModel
    {
        public Stock stock { get; set; }
        public List<Stock_Group> groups { get; set; }
        public List<Stock_Brand> brands { get; set; }
    }
}
