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
                .Where(a => !a.Durum).OrderByDescending(a => a.OlusturulmaTarihi).ToList();
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
                .Where(filter).OrderByDescending(a => a.OlusturulmaTarihi).ToList();
        }

        public List<TaskEntity> GetAllTasksWithUserId(int id)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Tasks.Where(a => a.AppUserId == id)
                .Include(a => a.Urgency)
                .Include(a => a.Reports)
                .Include(a => a.AppUser)
                .OrderByDescending(a => a.OlusturulmaTarihi).ToList();
        }
        public List<TaskEntity> GetNotFinishedTasks()
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Tasks.Where(a => !a.Durum)
                .Include(a => a.Urgency)
               .OrderByDescending(a => a.OlusturulmaTarihi).ToList();
        }

        public TaskEntity GetTaskWithReportProperty(int id)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Tasks.Where(a => a.Id == id)
                .Include(a => a.Reports)
                .Include(a => a.AppUser)
               .OrderByDescending(a => a.OlusturulmaTarihi).FirstOrDefault();
        }

        public TaskEntity GetTaskWithUrgencyProperty(int id)
        {
            using (var context = new DatabaseContext())
            {
                // eager loading .Include(a => a.UrgencyId)
                return context.Tasks.Where(a => !a.Durum && a.Id == id)
                    .Include(a => a.Urgency)
                    .FirstOrDefault();
            }
        }
    }
}
