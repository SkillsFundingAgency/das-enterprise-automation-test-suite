using System.IO;
using System.Reflection;

namespace SFA.DAS.FrameworkHelpers
{
    public static class FileHelper
    {
        public static string GetLocalProjectRootFilePath() => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"..\..\..\");

        public static string GetSql(string fileName) => GetFile(fileName, ".sql");

        private static string GetFile(string fileName, string extension)
        {
            string sqlScriptFile = GetPath($"{fileName}{extension}");

            string sqlScript = System.IO.File.ReadAllText(sqlScriptFile);
            sqlScript = sqlScript.Replace("\r\n", " ").Replace("\t", " ");
            return sqlScript;
        }

        public static string GetPath(string fileNamewithext)
        {
            var path = TestPlatformFinder.IsAzureExecution? $"{GetAzureSrcPath()}\\files" : GetLocalSrcPath();

            return Directory.GetFiles(path, fileNamewithext).First();
        }

        private static string GetAzureSrcPath() => GetSrcPath(AppDomain.CurrentDomain.BaseDirectory);

        private static string GetLocalSrcPath() => GetSrcPath(GetLocalProjectRootFilePath());

        private static string GetSrcPath(string projectPath) => Path.Combine(projectPath, @$"..\");  

    }
}
