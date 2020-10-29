using System.Collections.Generic;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Interfaces
{
    public interface ITaskRepository:IBaseRepository<TaskEntity>
    {
        List<TaskEntity> GetNotFinishedTasks();
        List<TaskEntity> GetAllTasksWithAllProperties();
        List<TaskEntity> GetAllTasksWithUserId(int id);
        TaskEntity GetTaskWithUrgencyProperty(int id);
        TaskEntity GetTaskWithReportProperty(int id);
    }
}
