﻿namespace LibraryTrackingApp.Application.Features.AppUsers.Events;

public class UserEventHandler : INotificationHandler<UserEvent>
{
    public UserEventHandler()
    {
     
    }

    public async Task Handle(UserEvent notification, CancellationToken cancellationToken)
    {
        switch (notification.RequestNotificationType)
        {
            case RequestNotificationType.Created:
                Console.WriteLine($"Yeni bir User oluşturuldu. User ID: {notification.UserId}");
                break;
            case RequestNotificationType.Updated:

                Console.WriteLine($"User güncellendi. User ID: {notification.UserId}");
                break;
            case RequestNotificationType.Deleted:
                Console.WriteLine($"User silindi. User ID: {notification.UserId}");
                break;
            case RequestNotificationType.FetchedSingle:
                Console.WriteLine($"User bilgileri alındı. User ID: {notification.UserId}");
                break;
            case RequestNotificationType.FetchedAll:
                Console.WriteLine("Tüm User bilgileri alındı.");
                break;
            default:
                Console.WriteLine("Tanımsız bir işlem türü alındı.");
                break;
        }
    }
}

