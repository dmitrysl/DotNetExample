using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetExample.Common.Utils.Json.Converters;

namespace DotNetExample.Common.Utils.Json
{
    public static class JsonSettings
    {
        public static JsonSerializerSettings GetDefaultJsonSerializerSettings(IContractResolver contractResolver = null, Formatting formatting = Formatting.None)
        {
            if (contractResolver == null)
            {
                contractResolver = new CamelCasePropertyNamesContractResolver();
            }

            var result = new JsonSerializerSettings()
            {
                Formatting = formatting,
                ContractResolver = contractResolver,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                Converters = new JsonConverter[]
                {
                    new StringEnumConverter { CamelCaseText = true },
                    new DecimalConverter(),
                    new IsoDateTimeConverter() {DateTimeStyles = DateTimeStyles.AdjustToUniversal }
                }
            };

            return result;
        }
    }
}
