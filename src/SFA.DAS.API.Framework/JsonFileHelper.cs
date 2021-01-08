using System;

namespace SFA.DAS.API.Framework
{
    public static class JsonFileHelper
    {
        public static string ReadAllText(string source)
        {
            string jsonBody = System.IO.File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\Project\\Tests\\Payload\\{source}");
            
            return jsonBody.Replace("\r\n", string.Empty).Replace("\t", string.Empty);
        }
    }
}
