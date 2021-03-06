﻿using System;
using System.Runtime.InteropServices;
using ServiceConnect;

namespace PublishSubscribe.Consumer1
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new PublishSubscribe.Messages.PublishSubscribeMessage(Guid.NewGuid());
            var name = message.GetType().FullName;

            Console.WriteLine("*********** Consumer 1 ***********");
            var bus = Bus.Initialize(x =>
            {
                x.ScanForMesssageHandlers = true;
                x.SetQueueName("Consumer1");
                x.SetHost("localhost");
            });

            bus.StartConsuming();

            Console.ReadLine();

            bus.Dispose();
        }
    }
}
