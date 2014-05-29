﻿using Newtonsoft.Json;
using R.MessageBus.Interfaces;

namespace R.MessageBus.Core
{
    /// <summary>
    /// Json message serializer.
    /// </summary>
    public class JsonMessageSerializer : IMessageSerializer
    {
        public object Deserialize(string messageJson)
        {
            var settings = new JsonSerializerSettings
            {
                Binder = new MessageSerializationBinder(),
                TypeNameHandling = TypeNameHandling.Objects
            };

            return JsonConvert.DeserializeObject(messageJson, settings);
        }

        public string Serialize(object message)
        {
            var settings = new JsonSerializerSettings
            {
                Binder = new MessageSerializationBinder(),
                TypeNameHandling = TypeNameHandling.Objects
            };

            return JsonConvert.SerializeObject(message, Formatting.Indented, settings);
        }
    }
}