using System;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public static class FileHelper
    {
        public static string GetSql(string source) => GetFile(source, ".sql");

        private static string GetFile(string source, string extension)
        {
            string sqlScriptFile = $"{GetAssemblyDirectory()}\\Project\\Helpers\\SqlScripts\\{source}{extension}";

            string sqlScript = System.IO.File.ReadAllText(sqlScriptFile);
            sqlScript = sqlScript.Replace("\r\n", " ").Replace("\t", " ");
            return sqlScript;
        }

        internal static string GetAssemblyDirectory() => AppDomain.CurrentDomain.BaseDirectory;
        
    }
}
