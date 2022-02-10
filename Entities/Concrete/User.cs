using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User: IEntity
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string code { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
    }
}
