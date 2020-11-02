using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Interfaces
{
    public interface ITaskRepository:IBaseRepository<TaskEntity>
    {
        List<TaskEntity> GetNotFinishedTasks();
        List<TaskEntity> GetAllTasksWithAllProperties();
        List<TaskEntity> GetAllTasksWithAllProperties(Expression<Func<TaskEntity, bool>> filter);
        List<TaskEntity> GetAllTasksWithUserId(int id);
        TaskEntity GetTaskWithUrgencyProperty(int id);
        TaskEntity GetTaskWithReportProperty(int id);
    }
}
