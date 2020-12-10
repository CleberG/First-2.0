using Fisrt2._0.Domain.Notifications;
using FluentValidation.Results;
using System.Collections.Generic;

namespace First2._0.Application.Services.Notifications
{
    public interface INotificationService
    {
        void AddNotification(string key, string value);
        void AddEntityNotifications(ValidationResult validationResult);
        bool HasNotifications();
        IReadOnlyCollection<Notification> GetNotifications();
    }
}
