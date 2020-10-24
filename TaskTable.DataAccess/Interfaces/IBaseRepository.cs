using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Interfaces;

namespace TaskTable.DataAccess.Interfaces
{
    public interface IBaseRepository<T> where T : class, ITablo, new()
    {
        void Ekle(T item);
        void Guncelle(T item);
        void Sil(T item);
        T Getir(int id);
        List<T> GetirHepsi();
    }
}
