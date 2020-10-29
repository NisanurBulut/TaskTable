using System.Collections.Generic;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Interfaces
{
    public interface ITaskRepository:IBaseRepository<TaskEntity>
    {
        List<TaskEntity> GetNotFinishedTasks();
        List<TaskEntity> GetAllTasksWithAllProperties();
    }
}
