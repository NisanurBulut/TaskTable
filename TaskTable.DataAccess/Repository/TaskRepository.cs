using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Repository
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public List<TaskEntity> GetirTamamlanmayanGorevler()
        {
            using (var context = new DatabaseContext())
            {
                // eager loading .Include(a => a.UrgencyId)
                return context.Tasks.Include(a => a.Urgency)
                    .Where(a => !a.Durum).OrderByDescending(a => a.OlusturulmaTarihi).ToList();
            }
        }
    }
}
