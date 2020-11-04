using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaskTable.Entity.Concrete;

namespace TaskTable.Business.Interfaces
{
    public interface ITaskService:IBaseService<TaskEntity>
    {
        List<TaskEntity> GetAllTasksWithAllProperties();
        // linq sorgusunu parametre almak istiyorsak expression geçmek zorundayız
        // bu linq sorgusunun tipi ne olsun?
        // func delegeler herhangi bir tipten değer alıp herhangi bir tipi geri döndüren yapılardı
        // func içine dönüş tipini de belirtiriz
        List<TaskEntity> GetAllTasksWithAllProperties(Expression<Func<TaskEntity, bool>> filter);
        List<TaskEntity> GetAllCompleteTasksWithAllProperties(out int totalPage, int userId, int activePage);
        List<TaskEntity> GetNotFinishedTasks();
        TaskEntity GetTaskWithUrgencyProperty(int id);
        TaskEntity GetTaskWithReportProperty(int id);
        List<TaskEntity> GetAllTasksWithUserId(int id);
        int GetCompletedTaskCountWithAppUserIdProperty(int id);
    }
}
