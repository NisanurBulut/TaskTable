using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskTable.DataAccess.Context;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.DataAccess.Repository
{
    public class NotificationRepository : BaseRepository<NotificationEntity>, INotificationRepository
    {
        public List<NotificationEntity> GetUnReadAll(int AppUserId)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Notifications.Where(a => !a.State && a.AppUserId==AppUserId).ToList();
        }

        public int GetUnReadNotificationCountwithAppUserId(int id)
        {
            using var context = new DatabaseContext();
            // eager loading .Include(a => a.UrgencyId)
            return context.Notifications.Where(a => !a.State && a.AppUserId == id).Count();
        }
    }
}
