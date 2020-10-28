using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Business.Interfaces;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.Business.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void Ekle(TaskEntity item)
        {
            _taskRepository.Ekle(item);
        }

        public TaskEntity Getir(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskEntity> GetirHepsi()
        {
            return _taskRepository.GetirHepsi();
        }

        public List<TaskEntity> GetirTamamlanmayanGorevler()
        {
            return _taskRepository.GetirTamamlanmayanGorevler();
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
