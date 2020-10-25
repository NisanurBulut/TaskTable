using System;
using System.Collections.Generic;
using System.Linq;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public void Ekle(TaskEntity item)
        {
            throw new NotImplementedException();
        }

        public TaskEntity Getir(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskEntity> GetirHepsi()
        {
            throw new NotImplementedException();
        }

        public void Guncelle(TaskEntity item)
        {
            throw new NotImplementedException();
        }

        public void Sil(TaskEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
