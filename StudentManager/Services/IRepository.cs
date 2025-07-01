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
        Task AddAsync(T student);
        Task RemoveAsync(T student);
        Task UpdateAsync(T student);

        void Add(T student);
        void Remove(T student);
        void Update(T student);

        IEnumerable<T> GetAll();
    }
}
