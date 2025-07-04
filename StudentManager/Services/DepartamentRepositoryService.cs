﻿using StudentManager.DataBase;
using StudentManager.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Services
{
    public class DepartamentRepositoryService : IRepository<Departament>
    {
        private DataBaseContext _db;
        public DepartamentRepositoryService(DataBaseContext db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Departament departament)
        {
            await _db.AddAsync(departament);
            await _db.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Departament> GetAll()
        {
            return _db.Set<Departament>();
        }

        public void Remove(Departament departament)
        {
            _db.Remove(departament);
            _db.SaveChanges();
        }

        public async Task RemoveAsync(Departament departament)
        {
            _db.Remove(departament);
            await _db.SaveChangesAsync();
        }


        public async Task<bool> UpdateAsync(Departament departament)
        {
            _db.Update(departament);
            await _db.SaveChangesAsync();
            return true;
        }

        public bool Add(Departament departament)
        {
            _db.AddAsync(departament);
            _db.SaveChanges();
            return true;
        }

        public bool Update(Departament departament)
        {
            _db.Update(departament);
            _db.SaveChanges();
            return true;
        }
    }
}
