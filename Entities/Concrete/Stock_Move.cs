using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Stock_Move: IEntity
    {
        [Key]
        public int id { get; set; }
        public int stock { get; set; }
        public int customer { get; set; }
        public bool move { get; set; } //true => stock out, false => stock in
        public double quantity { get; set; }
        public double unit_price { get; set; }
        public string description { get; set; }
        public int cuser { get; set; }
        public DateTime cdate { get; set; }
    }
}
