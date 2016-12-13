using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RudenSoftApp.DAL.Interfaces;
using RudenSoftApp.DAL.Entities;
using System.Data.Entity;

namespace RudenSoftApp.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AppContext db;
        private DbSet<T> table;
        public Repository(AppContext context)
        {
            this.db = context;
            table = db.Set<T>();
        }
        public void Create(T item)
        {
            table.Add(item);
        }
        public void Delete(int id)
        {
            T item = table.Find(id);
            if (item != null)
                table.Remove(item);
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return table.Where(predicate);
        }
        public T Get(int Id)
        {
            return table.Find(Id);
        }
        public IEnumerable<T> GetAll()
        {
            return table;
        }
        public void Update(T item)
        {
            /*
             * Присоединение используется для повторного заполнения контекста сущностью, 
             * о которой известно, что она присутствует в базе данных. 
             * Поэтому метод SaveChanges не будет пытаться вставить присоединенную сущность в базу данных, 
             * так как предполагается, что она там уже содержится. Обратите внимание, что сущности, 
             * которые уже содержатся в контексте в каком-либо другом состоянии, изменят свое состояние на неизмененное. 
             * Если сущность уже содержится в контексте в неизмененном состоянии, 
             * никаких действий при присоединении не выполняется. 
            */
            table.Attach(item);
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
