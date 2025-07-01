using Microsoft.EntityFrameworkCore;
using StudentManager.DataBase;
using StudentManager.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Services
{
    public class StudentRepositoryService : IRepository<Student>
    {
        private DataBaseContext _db;
        public StudentRepositoryService(DataBaseContext db) 
        {
            _db = db;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _db.AddAsync(student);
            await _db.SaveChangesAsync();
        }

        public  IEnumerable<Student> GetAllStudents()
        {
            return _db.Set<Student>();
        }

        public void RemoveStuden(Student student)
        {
            _db.Remove(student);
            _db.SaveChanges();
        }

        public async Task RemoveStudenAsync(Student student)
        {
            _db.Remove(student);
            await _db.SaveChangesAsync();
        }


        public async Task UpdateStudentAsync(Student student)
        {
            _db.Update(student);
            await _db.SaveChangesAsync();
        }

        void IRepository<Student>.AddStudent(Student student)
        {
            _db.AddAsync(student);
            _db.SaveChanges();
        }

        void IRepository<Student>.UpdateStudent(Student student)
        {
            _db.Update(student);
            _db.SaveChanges();
        }
    }
}
