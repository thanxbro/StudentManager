using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.DataBase.Data
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
