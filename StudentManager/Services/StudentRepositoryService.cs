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
    public class StudentRepositoryService : IRepository
    {
        private DataBaseContext _db;
        public StudentRepositoryService(DataBaseContext db) 
        {
            _db = db;
        }
        public async Task AddStudent(Student student)
        {
            await _db.AddAsync(student);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _db.Set<Student>().ToListAsync();
        }

        public async Task RemoveStudent(Student student)
        {
            _db.Remove(student);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            _db.Update(student);
            await _db.SaveChangesAsync();
        }
    }
}
