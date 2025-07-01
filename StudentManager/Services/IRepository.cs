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
        Task<bool> AddAsync(T student);
        Task RemoveAsync(T student);
        Task<bool> UpdateAsync(T student);

        bool Add(T student);
        void Remove(T student);
        bool Update(T student);

        IEnumerable<T> GetAll();
    }
}
