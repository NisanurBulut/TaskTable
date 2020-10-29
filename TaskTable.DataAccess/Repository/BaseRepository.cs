using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Interfaces;
namespace TaskTable.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, ITablo, new()
    {
        // context'in devamlı new olması transaction yapısına uygun deil
        // uow desgin pattern uygulanmalı.
        public void Add(T item)
        {
            using var context = new DatabaseContext();
            context.Set<T>().Add(item);
            context.SaveChanges();
        }
        public T Get(int id)
        {
            using var context = new DatabaseContext();
            return context.Set<T>().Find(id);
        }
        public List<T> GetAll()
        {
            using var context = new DatabaseContext();
            var test = context.Database.GetDbConnection();
            return context.Set<T>().ToList();
        }
        public void Update(T item)
        {
            using var context = new DatabaseContext();
            context.Set<T>().Update(item);
            context.SaveChanges();
        }
        public void Delete(T item)
        {
            using var context = new DatabaseContext();
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }
    }
}
