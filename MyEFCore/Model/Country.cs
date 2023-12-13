using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFCore.Model
{

    public class Country
    {
        public int Id { get; set; }
        [MaxLength(200), Required]
        public string Name { get; set; }
        public virtual Capital Capital { get; set; }
    }


    public class Capital
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }

    public class Parent
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<Child> Child { get; set; }
    }

    public class Child
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual Parent Parent { get; set; }
        [ForeignKey("ParentId")]
        public int ParentId { get; set; }
    }

    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<Student> Student { get; set; }
    }

    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateBirth { get; set; }
        public virtual List<Teacher> Teacher { get; set; }
    }
}
