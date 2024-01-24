using System.Text.Json;

namespace SFA.DAS.FrameworkHelpers
{
    public static class JsonHelper
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions;

        static JsonHelper()
        {
            jsonSerializerOptions = new()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }
        public static string ReadAllText(string source)
        {
            string jsonBody = System.IO.File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\Project\\Tests\\Payload\\{source}");

            return jsonBody.Replace("\r\n", string.Empty).Replace("\t", string.Empty);
        }

        public static string Serialize<T>(T data) => string.IsNullOrEmpty(data?.ToString()) ? string.Empty : JsonSerializer.Serialize(data, jsonSerializerOptions);
    }
}