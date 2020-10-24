using System;
using System.Collections.Generic;
using System.Linq;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Repository
{
    public class CalismaRepository : ICalismaRepository
    {
        public CalismaEntity GetirCalisma(int id)
        {
            using var context = new DatabaseContext();
            return context.Calismas.Find(id);
        }

        public List<CalismaEntity> GetirCalismalar()
        {
            using var context = new DatabaseContext();
            return context.Calismas.ToList();
        }

        public void KaydetCalisma(CalismaEntity calisma)
        {
            
        }

        public void SilCalisma(CalismaEntity calisma)
        {
            
        }
    }
}
