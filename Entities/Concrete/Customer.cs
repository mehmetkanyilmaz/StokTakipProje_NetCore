using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer: IEntity
    {
        [Key]
        public int id { get; set; }
        //Tedarikçi ise vergi numarası
        public string tc { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public int city { get; set; }
        public int district { get; set; }
        public string address { get; set; }
        //true tedarikci, false müşteri anlamına gelir.
        public bool supplier { get; set; }
    }
}
