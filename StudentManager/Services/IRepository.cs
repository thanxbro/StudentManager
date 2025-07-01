using StudentManager.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Services
{
    public interface IRepository<T>
    {
        Task AddStudentAsync(T student);
        Task RemoveStudenAsync(T student);
        Task UpdateStudentAsync(T student);

        void AddStudent(T student);
        void RemoveStuden(T student);
        void UpdateStudent(T student);

        IEnumerable<T> GetAllStudents();
    }
}
