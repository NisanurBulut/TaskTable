using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Interfaces;

namespace TaskTable.Business.Interfaces
{
    public interface IBaseService<T> where T:class,ITablo,new()
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T Get(int id);
        List<T> GetAll();
    }
}
