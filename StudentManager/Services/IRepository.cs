using StudentManager.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Services
{
    public interface IRepository
    {
        Task AddStudent(Student student);
        Task RemoveStudent(Student student);
        Task<List<Student>> GetAllStudents();

        Task UpdateStudent(Student student);
    }
}
