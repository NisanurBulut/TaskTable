﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TaskTable.Entity.Concrete;
namespace TaskTable.DataAccess.Interfaces
{
    public interface INotificationRepository:IBaseRepository<NotificationEntity>
    {
        List<NotificationEntity> GetUnReadAll(int AppUserId);
        int GetUnReadNotificationCountwithAppUserId(int id);
    }
}
