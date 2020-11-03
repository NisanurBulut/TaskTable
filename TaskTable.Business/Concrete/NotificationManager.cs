using System;
using System.Collections.Generic;
using System.Text;
using TaskTable.Business.Interfaces;
using TaskTable.DataAccess.Interfaces;
using TaskTable.Entity.Concrete;

namespace TaskTable.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationManager(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public void Add(NotificationEntity item)
        {
            _notificationRepository.Add(item);
        }

        public void Delete(NotificationEntity item)
        {
            _notificationRepository.Delete(item);
        }

        public NotificationEntity Get(int id)
        {
            return _notificationRepository.Get(id);
        }

        public List<NotificationEntity> GetAll()
        {
            return _notificationRepository.GetAll();
        }

        public List<NotificationEntity> GetUnReadAll(int AppUserId)
        {
            return _notificationRepository.GetUnReadAll(AppUserId);
        }

        public void Update(NotificationEntity item)
        {
            _notificationRepository.Update(item);
        }
    }
}
