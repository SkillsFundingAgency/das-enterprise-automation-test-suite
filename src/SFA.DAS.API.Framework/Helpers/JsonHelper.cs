using System;
using System.Text.Json;

namespace SFA.DAS.API.Framework.Helpers
{
    public static class JsonHelper
    {
        public static string ReadAllText(string source)
        {
            string jsonBody = System.IO.File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\Project\\Tests\\Payload\\{source}");

            return jsonBody.Replace("\r\n", string.Empty).Replace("\t", string.Empty);
        }

        public static string Serialize<T>(T data)
        {
            JsonSerializerOptions jso = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            return string.IsNullOrEmpty(data?.ToString()) ? string.Empty : JsonSerializer.Serialize(data, jso);
        }
    }
}