using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Stock_Brand : IEntity
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
