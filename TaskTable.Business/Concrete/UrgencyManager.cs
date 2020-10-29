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
        public void Add(UrgencyEntity item)
        {
             _urgencyRep.Add(item);
        }
        public UrgencyEntity Get(int id)
        {
           return _urgencyRep.Get(id);
        }
        public List<UrgencyEntity> GetAll()
        {
            return _urgencyRep.GetAll();
        }
        public void Update(UrgencyEntity item)
        {
            _urgencyRep.Update(item);
        }
        public void Delete(UrgencyEntity item)
        {
            _urgencyRep.Delete(item);
        }
    }
}
