using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Business.Interfaces;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;
namespace TaskTable.Business.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly IUrgencyRepository _urgencyRep;
        public UrgencyManager(IUrgencyRepository urgencyRepository)
        {
            _urgencyRep = urgencyRepository;
        }
        public void Ekle(UrgencyEntity item)
        {
             _urgencyRep.Add(item);
        }
        public UrgencyEntity Getir(int id)
        {
           return _urgencyRep.Get(id);
        }
        public List<UrgencyEntity> GetirHepsi()
        {
            return _urgencyRep.GetAll();
        }
        public void Guncelle(UrgencyEntity item)
        {
            _urgencyRep.Update(item);
        }
        public void Sil(UrgencyEntity item)
        {
            _urgencyRep.Delete(item);
        }
    }
}
