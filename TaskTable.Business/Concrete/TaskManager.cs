using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        public void Add(TaskEntity item)
        {
            _taskRepository.Add(item);
        }
        public List<TaskEntity> GetAllTasksWithAllProperties(Expression<Func<TaskEntity, bool>> filter)
        {
            return _taskRepository.GetAllTasksWithAllProperties(filter);
        }
        public List<TaskEntity> GetAllTasksWithAllProperties()
        {
            return _taskRepository.GetAllTasksWithAllProperties();
        }

        public List<TaskEntity> GetAllTasksWithUserId(int id)
        {
            return _taskRepository.GetAllTasksWithUserId(id);
        }

        public TaskEntity Get(int id)
        {
            return _taskRepository.Get(id);
        }
        public List<TaskEntity> GetAll()
        {
            return _taskRepository.GetAll();
        }
        public List<TaskEntity> GetNotFinishedTasks()
        {
            return _taskRepository.GetNotCompletedTasks();
        }
        public TaskEntity GetTaskWithUrgencyProperty(int id)
        {
            return _taskRepository.GetTaskWithUrgencyProperty(id);
        }
        public void Update(TaskEntity item)
        {
            _taskRepository.Update(item);
        }
        public void Delete(TaskEntity item)
        {
            _taskRepository.Delete(item);
        }

        public TaskEntity GetTaskWithReportProperty(int id)
        {
            return _taskRepository.GetTaskWithReportProperty(id);
        }

        public List<TaskEntity> GetAllCompleteTasksWithAllProperties(out int totalPage, int userId, int activePage)
        {
            return _taskRepository.GetAllCompleteTasksWithAllProperties(out totalPage, userId, activePage);
        }

        public int GetCompletedTaskCountWithAppUserIdProperty(int id)
        {
            return _taskRepository.GetCompletedTaskCountWithAppUserIdProperty(id);
        }

        public int GetUnCompletedTaskCountWithAppUserIdProperty(int id)
        {
            return _taskRepository.GetCompletedTaskCountWithAppUserIdProperty(id);
        }

        public int GetNotAssignTaskCount()
        {
            return _taskRepository.GetNotAssignTaskCount();
        }

        public int GetNotCompletedTaskCount()
        {
            return _taskRepository.GetNotCompletedTaskCount();
        }

        public int GetComplatedAssignTaskCount()
        {
            return _taskRepository.GetComplatedAssignTaskCount();
        }

    }
}
