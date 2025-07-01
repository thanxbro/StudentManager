using StudentManager.DataBase;
using StudentManager.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Services
{
    public class TeacherRepositorySrvice : IRepository<Teacher>
    {
        private DataBaseContext _db;
        public TeacherRepositorySrvice(DataBaseContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _db.AddAsync(teacher);
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _db.Set<Teacher>();
        }

        public void Remove(Teacher teacher)
        {
            _db.Remove(teacher);
            _db.SaveChanges();
        }

        public async Task RemoveAsync(Teacher teacher)
        {
            _db.Remove(teacher);
            await _db.SaveChangesAsync();
        }


        public async Task UpdateAsync(Teacher teacher)
        {
            _db.Update(teacher);
            await _db.SaveChangesAsync();
        }

        void IRepository<Teacher>.Add(Teacher teacher)
        {
            _db.AddAsync(teacher);
            _db.SaveChanges();
        }

        void IRepository<Teacher>.Update(Teacher teacher)
        {
            _db.Update(teacher);
            _db.SaveChanges();
        }
    }
}
