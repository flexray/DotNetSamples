using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageExamples
{
    // FIFO
    // 30 second lock

    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Queue;
    using System;
    using System.Configuration;
    using System.Diagnostics;
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("storageexamplequeue");
            queue.CreateIfNotExists();
            queue.AddMessage(new CloudQueueMessage("Message #1"));
            queue.AddMessage(new CloudQueueMessage("Message #2"));
            queue.AddMessage(new CloudQueueMessage("Message #3"));

            // Check which message is the next one
            CloudQueueMessage peekedMessage = queue.PeekMessage();
            Debug.WriteLine("Next message to get: " + peekedMessage.AsString);

            CloudQueueMessage message1 = queue.GetMessage();
            CloudQueueMessage message2 = queue.GetMessage();
            CloudQueueMessage message3 = queue.GetMessage();

            Debug.WriteLine("#1: " + message1.AsString);
            Debug.WriteLine("#2: " + message2.AsString);
            Debug.WriteLine("#3: " + message2.AsString);

            queue.DeleteMessage(message1);
            queue.DeleteMessage(message2);
            queue.DeleteMessage(message3);

        }
    }
}
