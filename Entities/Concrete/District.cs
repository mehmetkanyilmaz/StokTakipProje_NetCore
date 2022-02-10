using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class District : IEntity
    {
        [Key]
        public int id { get; set; }
        public int city { get; set; }
        public string district { get; set; }
    }
}
