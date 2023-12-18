using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFCore.Model
{
    [Table("Car")]
    public class Car
    {
        [Key]
        public int id { get; set; }        
        public string model { get; set; }
        public string company { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public string distance { get; set; }
    }
}
