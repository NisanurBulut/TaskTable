using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Entity.Concrete;

namespace TaskTable.Business.Interfaces
{
    public interface INotificationService : IBaseService<NotificationEntity>
    {
        List<NotificationEntity> GetUnReadAll(int AppUserId);
        int GetUnReadNotificationCountwithAppUserId(int id);
    }
}
