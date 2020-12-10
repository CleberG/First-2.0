using First2._0.Application.Services.Notifications;
using Fisrt2._0.Domain;

namespace First2._0.Application.Services.Base
{
    public abstract class AbstractService
    {
        protected static bool HasNotification<T>(EntidadeBase entity, INotificationService notificationService)
         where T : EntidadeBase
        {
            if (entity is null)
            {
                notificationService.AddNotification($"{typeof(T).Name}NotFound",
                    $"{typeof(T).Name} não encontrado.");
                return true;
            }
            return false;
        }
    }
}
