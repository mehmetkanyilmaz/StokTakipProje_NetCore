using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StockListDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string group_name { get; set; }
        public string brand_name { get; set; }
        public string model_name { get; set; }
        public double unit_price { get; set; }
        public double quantity { get; set; }
        public string image { get; set; }
        public bool status { get; set; }
        public int cuser { get; set; }
        public DateTime cdate { get; set; }
        public int muser { get; set; }
        public DateTime mdate { get; set; }
    }
}
