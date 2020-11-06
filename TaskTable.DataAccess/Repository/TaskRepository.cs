using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Repository
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public List<TaskEntity> GetAllTasksWithAllProperties()
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Tasks
                .Include(a => a.Urgency)
                .Include(a => a.Reports)
                .Include(a => a.AppUser)
                .Where(a => !a.State).OrderByDescending(a => a.CreationDate).ToList();
        }

        public List<TaskEntity> GetAllTasksWithAllProperties(Expression<Func<TaskEntity, bool>> filter)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            // predicate delege dolayısıyla bool dönüyor
            // bir func delege predicate delegenin yaptığı işi de görebilir.
            return context.Tasks
                .Include(a => a.Urgency)
                .Include(a => a.Reports)
                .Include(a => a.AppUser)
                .Where(filter).OrderByDescending(a => a.CreationDate).ToList();
        }

        public List<TaskEntity> GetAllTasksWithUserId(int id)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Tasks.Where(a => a.AppUserId == id)
                .Include(a => a.Urgency)
                .Include(a => a.Reports)
                .Include(a => a.AppUser)
                .OrderByDescending(a => a.CreationDate).ToList();
        }

        public List<TaskEntity> GetAllCompleteTasksWithAllProperties(out int totalPage, int userId, int activePage)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            var returnValue = context.Tasks
                 .Include(a => a.Urgency)
                 .Include(a => a.Reports)
                 .Include(a => a.AppUser)
                 .Where(a => a.AppUserId == userId && a.State == true)
                 .Skip((1 - activePage) * 3)
                 .Take(3)
                 .OrderByDescending(a => a.CreationDate);
            totalPage = (int)Math.Ceiling((double)(returnValue.Count() / 3));
            return returnValue.ToList();
        }

        public List<TaskEntity> GetNotCompletedTasks()
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Tasks.Where(a => a.State == false)
                .Include(a => a.Urgency)
               .OrderByDescending(a => a.CreationDate).ToList();
        }

        public TaskEntity GetTaskWithReportProperty(int id)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Tasks.Where(a => a.Id == id)
                .Include(a => a.Reports)
                .Include(a => a.AppUser)
               .OrderByDescending(a => a.CreationDate).FirstOrDefault();
        }

        public TaskEntity GetTaskWithUrgencyProperty(int id)
        {
            using (var context = new DatabaseContext())
            {
                // eager loading .Include(a => a.UrgencyId)
                return context.Tasks.Where(a => !a.State && a.Id == id)
                    .Include(a => a.Urgency)
                    .FirstOrDefault();
            }
        }

        public int GetCompletedTaskCountWithAppUserIdProperty(int id)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Tasks.Where(a => a.State == true).Count();
        }

        public int GetUnCompletedTaskCountWithAppUserIdProperty(int id)
        {
            using var context = new DatabaseContext();
            return context.Tasks.Where(a => a.State == false).Count();
        }

        public int GetNotAssignTaskCount()
        {
            // atanma bekleyen görev sayısı
            using var context = new DatabaseContext();
            return context.Tasks.Where(a => a.State == false && a.AppUserId == null).Count();
        }

        public int GetNotCompletedTaskCount()
        {
            // atanmış ve devam eden görev sayısı
            using var context = new DatabaseContext();
            return context.Tasks.Where(a => a.State == false && a.AppUserId != null).Count();
        }

        public int GetComplatedAssignTaskCount()
        {
            // tamamlanmış görev sayısı
            using var context = new DatabaseContext();
            return context.Tasks.Where(a => a.State == true).Count();
        }

    }
}
