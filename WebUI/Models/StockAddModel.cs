using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class StockAddModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int group { get; set; }
        public int brand { get; set; }
        public int model { get; set; }
        public double unit_price { get; set; }
        public double quantity { get; set; }
        public IFormFile image { get; set; }
        public bool status { get; set; }
        public int cuser { get; set; }
        public DateTime cdate { get; set; }
        public int muser { get; set; }
        public DateTime mdate { get; set; }
    }
}
