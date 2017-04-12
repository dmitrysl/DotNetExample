using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExample.Common.Utils.Json
{
    /// <summary>
    /// Represents the functionality to serialize objects to json and deserialize it.
    /// </summary>
    public static class JsonExtensions
    {
        public static readonly JsonSerializerSettings LegacyJsonSettings;
        private static readonly JsonSerializerSettings DefaultJsonSettings;
        private static readonly JsonSerializerSettings PlainJsonSettings;

        static JsonExtensions()
        {
            DefaultJsonSettings = GetDefaultSettings(Formatting.Indented);
            PlainJsonSettings = GetDefaultSettings(Formatting.None);
            LegacyJsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
        }

        public static string ToJson(this object obj, bool? isIndent = null)
        {
            JsonSerializerSettings settings = isIndent.HasValue && !isIndent.Value ? PlainJsonSettings : DefaultJsonSettings;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static string ToJson(this object obj, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(obj, settings ?? DefaultJsonSettings);
        }

        public static T ToJsonObject<T>(this string json)
        {
            return (T)JsonConvert.DeserializeObject(json, typeof(T));
        }

        public static T ToJsonObject<T>(this string json, T typeToCastTo)
        {
            return (T)JsonConvert.DeserializeObject(json, typeToCastTo.GetType());
        }

        public static T ToJsonObject<T>(this string json, Type type)
        {
            return (T)JsonConvert.DeserializeObject(json, type);
        }

        public static object ToJsonObjectByType(this string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        public static T FromJson<T>(this string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj, DefaultJsonSettings);
        }

        public static string ToLegacyJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, LegacyJsonSettings);
        }

        public static T FromLegacyJson<T>(this string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj, LegacyJsonSettings);
        }

        private static JsonSerializerSettings GetDefaultSettings(Formatting formatting)
        {
            return JsonSettings.GetDefaultJsonSerializerSettings(formatting: formatting);
        }
    }
}
