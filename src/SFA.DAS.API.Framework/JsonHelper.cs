using System.Text.Json;

namespace SFA.DAS.API.Framework
{
    public static class JsonHelper
    {
        public static string Serialize<T>(T data)
        {
            JsonSerializerOptions jso = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            return JsonSerializer.Serialize(data, jso);
        }
    }
}