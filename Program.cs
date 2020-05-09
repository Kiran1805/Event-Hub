using System;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using System.Threading.Tasks;

namespace AzureEventHubReceiver
{
    class Program
    {
            private const string EventHubConnectionString = "Endpoint=sb://notifyhubkk.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3p4bQKGnzZAsDZXB+5/WAuGrmfuyLluRIQEnjgK8Zwc=";
            private const string EventHubName = "myfirsteventhub";
            private const string StorageContainerName = "myfirstblob";
            private const string StorageAccountName = "mystoragekk";
            private const string StorageAccountKey = "DefaultEndpointsProtocol=https;AccountName=mystoragekk;AccountKey=8bGD702FRby/3sT561OnFhz7xV03yRxedOw/Lwf4NCNA4mOfLaD585FLivRYEvpbKQIl+goAw7gt7Js12OlbNA==;EndpointSuffix=core.windows.net";

        //    private static readonly string StorageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", StorageAccountName, StorageAccountKey);

            public static void Main(string[] args)
            {
                MainAsync(args).GetAwaiter().GetResult();
            }

            private static async Task MainAsync(string[] args)
            {
                Console.WriteLine("Registering EventProcessor...");

                var eventProcessorHost = new EventProcessorHost(
                    EventHubName,
                    PartitionReceiver.DefaultConsumerGroupName,
                    EventHubConnectionString,
                    StorageAccountKey,
                    StorageContainerName);

                // Registers the Event Processor Host and starts receiving messages
                await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

                Console.WriteLine("Receiving. Press ENTER to stop worker.");
                Console.ReadLine();

                // Disposes of the Event Processor Host
                await eventProcessorHost.UnregisterEventProcessorAsync();
            }
        }
}
