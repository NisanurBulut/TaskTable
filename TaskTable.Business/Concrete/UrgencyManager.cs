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
             _urgencyRep.Ekle(item);
        }

        public UrgencyEntity Getir(int id)
        {
           return _urgencyRep.Getir(id);
        }

        public List<UrgencyEntity> GetirHepsi()
        {
            return _urgencyRep.GetirHepsi();
        }

        public void Guncelle(UrgencyEntity item)
        {
            _urgencyRep.Guncelle(item);
        }

        public void Sil(UrgencyEntity item)
        {
            _urgencyRep.Sil(item);
        }
    }
}
