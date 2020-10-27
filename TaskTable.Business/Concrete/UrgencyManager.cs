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
        public void AddUrgency(UrgencyEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<UrgencyEntity> GetAllUrgency()
        {
            return _urgencyRep.GetirHepsi();
        }

        public UrgencyEntity GetUrgency(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUrgency(UrgencyEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
