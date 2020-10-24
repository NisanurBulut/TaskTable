using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Interfaces;

namespace TaskTable.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, ITablo, new()
    {
        // context'in devamlı new olması transaction yapısına uygun deil
        // uow desgin pattern uygulanmalı.
        public void Ekle(T item)
        {
            using var context = new DatabaseContext();
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public T Getir(int id)
        {
            using var context = new DatabaseContext();
            return context.Set<T>().Find(id);
        }

        public List<T> GetirHepsi()
        {
            using var context = new DatabaseContext();
            return context.Set<T>().ToList();
        }

        public void Guncelle(T item)
        {
            using var context = new DatabaseContext();
            context.Set<T>().Update(item);
            context.SaveChanges();
        }

        public void Sil(T item)
        {
            using var context = new DatabaseContext();
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }
    }
}
