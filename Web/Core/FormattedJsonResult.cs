using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace QWERTY.Web.Core
{
    public class FormattedJsonResult : JsonResult
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter> { new StringEnumConverter() }
        };

        public override void ExecuteResult(ControllerContext context)
        {
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(a: context.HttpContext.Request.HttpMethod, b: "GET", comparisonType: StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(message: "GET request not allowed");
            }

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(value: this.ContentType) ? this.ContentType : "application/json";

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Data == null)
            {
                return;
            }

            response.Write(s: JsonConvert.SerializeObject(value: this.Data, settings: Settings));
        }
    }
}