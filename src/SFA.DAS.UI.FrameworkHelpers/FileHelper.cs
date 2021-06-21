using System;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public static class FileHelper
    {
        public static string GetSql(string source) => GetFile(source, ".sql");

        private static string GetFile(string source, string extension)
        {
            string sqlScriptFile = $"{AppDomain.CurrentDomain.BaseDirectory}\\Project\\Helpers\\SqlScripts\\{source}{extension}";

            string sqlScript = System.IO.File.ReadAllText(sqlScriptFile);
            sqlScript = sqlScript.Replace("\r\n", " ").Replace("\t", " ");
            return sqlScript;
        }
    }
}
