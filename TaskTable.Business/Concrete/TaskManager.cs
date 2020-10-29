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
            _taskRepository.Add(item);
        }
        public List<TaskEntity> GetAllTasksWithAllProperties()
        {
            return _taskRepository.GetAllTasksWithAllProperties();
        }
        public TaskEntity Getir(int id)
        {
            return _taskRepository.Get(id);
        }
        public List<TaskEntity> GetirHepsi()
        {
            return _taskRepository.GetAll();
        }
        public List<TaskEntity> GetNotFinishedTasks()
        {
            return _taskRepository.GetNotFinishedTasks();
        }
        public TaskEntity GetTaskWithUrgencyProperty(int id)
        {
            return _taskRepository.GetTaskWithUrgencyProperty(id);
        }
        public void Guncelle(TaskEntity item)
        {
            _taskRepository.Update(item);
        }
        public void Sil(TaskEntity item)
        {
            _taskRepository.Delete(item);
        }
    }
}
