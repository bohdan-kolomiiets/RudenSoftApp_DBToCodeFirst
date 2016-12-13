using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudenSoftApp.DAL.Entities;

namespace RudenSoftApp.DAL.Interfaces
{
    public interface IClientManager<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
