using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;

namespace PushNotificationSender
{
    class Program
    {
        static void Main(string[] args)
        {
            SendNotificationAsync();
            Console.ReadKey();
        }
        public static async void SendNotificationAsync()
        {
            NotificationHubClient hub = NotificationHubClient
                .CreateClientFromConnectionString(
                "Endpoint=sb://notofiyhubkk.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=2yZYnkGXywUsFeRhlWXcxIAXIIWY02FAX0CnZkTyfOk=",
                "myfirstnotifyhub");
            var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">Grab 10% Cashback on your Dish TV Recharges</text></binding></visual></toast>";
            await hub.SendWindowsNativeNotificationAsync(toast);
        }

    }
}
