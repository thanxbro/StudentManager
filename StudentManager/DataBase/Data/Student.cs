using StudentManager.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.DataBase.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(60)]
        public string? Middlename { get; set;}

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [ForeignKey("TeacherKey")]
        public List<Teacher> Teachers { get; set; }
        public int DepartamentId { get; set; }  
        public Departament Departament { get; set; }

    }
}
