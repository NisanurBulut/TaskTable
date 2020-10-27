using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;

namespace TaskTable.Business.Interfaces
{
    public interface IUrgencyService
    {
        public void AddUrgency(UrgencyEntity entity);
        public void UpdateUrgency(UrgencyEntity entity);
        public UrgencyEntity GetUrgency(int id);
        public List<UrgencyEntity> GetAllUrgency();

    }
}
