using System;

namespace AzureEventHubSender
{
        using System;
        using System.Text;
        using System.Threading.Tasks;
        using Microsoft.Azure.EventHubs;
        public class Program
        {
            private static EventHubClient eventHubClient;
            private const string EventHubConnectionString = "Endpoint=sb://notifyhubkk.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3p4bQKGnzZAsDZXB+5/WAuGrmfuyLluRIQEnjgK8Zwc=";
            private const string EventHubName = "myfirsteventhub";

            public static void Main(string[] args)
            {
                MainAsync(args).GetAwaiter().GetResult();
            }

            private static async Task MainAsync(string[] args)
            {
                // Creates an EventHubsConnectionStringBuilder object from the connection string, and sets the EntityPath.
                // Typically, the connection string should have the entity path in it, but for the sake of this simple scenario
                // we are using the connection string from the namespace.
                var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventHubConnectionString)
                {
                    EntityPath = EventHubName
                };

                eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

                await SendMessagesToEventHub();

                await eventHubClient.CloseAsync();

                Console.WriteLine("Press ENTER to exit.");
                Console.ReadLine();
            }

            // Uses the event hub client to send 100 messages to the event hub.
            private static async Task SendMessagesToEventHub()
            {
                    try
                    {
                        var message = $"{DateTime.Now} 1805199";
                        Console.WriteLine($"Sending message: {message}");
                        await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                    }

                    await Task.Delay(10);

                Console.WriteLine($"message sent.");
            }
        }
}
