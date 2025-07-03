using Microsoft.EntityFrameworkCore;
using StudentManager.DataBase;
using StudentManager.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManager.Services
{
    public class StudentRepositoryService : IRepository<Student>
    {
        private DataBaseContext _db;
        public StudentRepositoryService(DataBaseContext db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Student student)
        {


            await _db.AddAsync(student);
            await _db.SaveChangesAsync();
            return true;

        }

        public IEnumerable<Student> GetAll()
        {
            return _db.Set<Student>().Include(s => s.Departament).Include(s => s.Teachers);
        }

        public void Remove(Student student)
        {
            _db.Remove(student);
            _db.SaveChanges();
        }

        public async Task RemoveAsync(Student student)
        {
            _db.Remove(student);
            await _db.SaveChangesAsync();
        }


        public async Task<bool> UpdateAsync(Student student)
        {

            _db.Update(student);
            await _db.SaveChangesAsync();
            return true;



        }

        public bool Add(Student student)
        {

            _db.AddAsync(student);
            _db.SaveChanges();
            return true;


        }

        public bool Update(Student student)
        {
            _db.Update(student);
            _db.SaveChanges();
            return true;

        }

    }
}
