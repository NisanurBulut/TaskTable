using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Business.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.Business.Concrete
{
    public class TaskManager : ITaskService
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
