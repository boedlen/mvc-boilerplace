using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_boilerplate.BL
{
    public enum StatusCode
    {
        Ok = 200,
        Error = 500
    }

    /// <summary>
    /// Returns Json response
    /// </summary>
    public class JsonResponse : ActionResult
    {
        public object Data { get; set; }
        public string ContentType { get; set; }
        public StatusCode StatusCode { get; set; }

        private JsonResponse(StatusCode statusCode, object data = null, string contentType = null)
        {
            this.Data = data;
            this.StatusCode = statusCode;
            this.ContentType = contentType ?? "application/json";
        }

        public override void ExecuteResult(ControllerContext context)
        {
            // Set desired serializer options
            var serializerOptions = new JsonSerializerSettings
            {
                FloatFormatHandling = FloatFormatHandling.DefaultValue,
                TypeNameHandling = TypeNameHandling.None,
                NullValueHandling = NullValueHandling.Include,
                ContractResolver = new CamelCasePropertyNamesContractResolver { }
            };

            // Build desired output object
            var jsonData = new
            {
                status = this.StatusCode.ToString(),
                data = this.Data
            };

            // Serialize data
            var result = JsonConvert.SerializeObject(jsonData, Formatting.Indented, serializerOptions);

            // Write out result
            context.HttpContext.Response.StatusCode = (int)this.StatusCode;
            context.HttpContext.Response.ContentType = this.ContentType;
            context.HttpContext.Response.Write(result);
        }

        /// <summary>
        /// Output object as JSON, with status code 200
        /// </summary>
        public static JsonResponse Ok(object data = null, string contentType = null)
        {
            return new JsonResponse(StatusCode.Ok, data, contentType);
        }

        /// <summary>
        /// Output object as JSON, with status code 500
        /// </summary>
        public static JsonResponse Error(object data = null, string contentType = null)
        {
            return new JsonResponse(StatusCode.Error, data, contentType);
        }
    }
}