using Fisrt2._0.Domain.Notifications;
using FluentValidation.Results;
using System.Collections.Generic;

namespace First2._0.Application.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationContext _notificationContext;
        public NotificationService(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public void AddEntityNotifications(ValidationResult validationResult)
        {
            _notificationContext.AddNotifications(validationResult);
        }

        public void AddNotification(string key, string value)
        {
            _notificationContext.AddNotification(key, value);

        }

        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return _notificationContext.Notifications;
        }

        public bool HasNotifications()
        {
            return _notificationContext.HasNotifications;
        }
    }
}
