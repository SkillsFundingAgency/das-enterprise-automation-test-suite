namespace SFA.DAS.FrameworkHelpers
{
    public static class FileHelper
    {
        public static string GetSql(string source) => GetFile(source, ".sql");

        private static string GetFile(string source, string extension)
        {
            string sqlScriptFile = $"{GetAzurePath()}\\Project\\Helpers\\SqlScripts\\{source}{extension}";

            string sqlScript = System.IO.File.ReadAllText(sqlScriptFile);
            sqlScript = sqlScript.Replace("\r\n", " ").Replace("\t", " ");
            return sqlScript;
        }

        public static string GetPath() => TestPlatformFinder.IsAzureExecution ? GetAzurePath() : GetLocalPath();

        public static string GetAzurePath() => $"{AppDomain.CurrentDomain.BaseDirectory}\\files";

        public static string GetLocalPath() => AppDomain.CurrentDomain.BaseDirectory;


    }
}
