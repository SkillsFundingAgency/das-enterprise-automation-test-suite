using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace SFA.DAS.FrameworkHelpers
{
    public static class FileHelper
    {
        public static string GetDownloadsDirectoryPath() => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");

        public static string GetLocalProjectRootFilePath() => Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"..\..\..\"));

        public static string GetAzureSrcFilesPath() => $"{GetAzureSrcPath()}\\files";

        public static string GetSingleConfigJson(string fileName) => GetPath($"appsettings.{fileName}", ".json");

        public static string GetProjectConfigJson(string fileName)
        {
            var fullFileName = $"appsettings.{fileName}.json";

            var path = TestPlatformFinder.IsAdoExecution ? GetAzureProjectConfigFilePath() : GetLocalProjectRootFilePath();

            string[] files = Directory.Exists(path) ? Directory.GetFiles(path, fullFileName) : [];

            return files.Length != 0 ? files.First() : fullFileName;
        }

        public static string GetJs(string fileName) => GetPath(fileName, ".js");

        public static string GetSql(string fileName)
        {
            string sqlScriptFile = GetPath(fileName, ".sql");

            string sqlScript = File.ReadAllText(sqlScriptFile);

            sqlScript = sqlScript.Replace("\r\n", " ").Replace("\t", " ");

            return sqlScript;
        }

        internal static string GetPath(string fileName, string extension)
        {
            bool isAzureExecution = TestPlatformFinder.IsAdoExecution;

            var path = isAzureExecution ? GetAzureSrcFilesPath() : GetLocalSrcPath();

            string[] files = Directory.GetFiles(path, $"{fileName}{extension}", new EnumerationOptions { RecurseSubdirectories = !isAzureExecution });

            return files.First();
        }

        private static string GetAzureProjectConfigFilePath()
        {
            var projectName = ProjectNameRegexHelper.ProjectNameRegex().Match(AppDomain.CurrentDomain.BaseDirectory).Value;

            var azureSrcPath = $"{GetAzureSrcPath()}\\src\\{projectName}";

            return azureSrcPath;
        }

        private static string GetAzureSrcPath() => GetSrcPath(AppDomain.CurrentDomain.BaseDirectory);

        private static string GetLocalSrcPath() => GetSrcPath(GetLocalProjectRootFilePath());

        private static string GetSrcPath(string projectPath) => Path.GetFullPath(Path.Combine(projectPath, @$"..\"));

        public static string GetDownloadedFileName(string pageName, string format)
        {
            string downloadedFileName = string.Empty;
            string filename = $"{pageName}_{DateTime.Now:yyyyMMdd}*.{format}";
            string path = GetDownloadsDirectoryPath();

            string[] filePaths = Directory.GetFiles(path, filename);

            downloadedFileName = filePaths.OrderByDescending(filePath =>
            {
                var fileInfo = new FileInfo(filePath);
                return fileInfo.LastWriteTime;
            }).First();

            return downloadedFileName;
        }

        public static int CountCsvFileRows(string fullPath)
        {
            int rowCount = 0;

            if (File.Exists(fullPath))
            {
                using StreamReader reader = new(fullPath);
                while (reader.ReadLine() != null)
                {
                    rowCount++;
                }
            }

            return rowCount;
        }
    }

    [TestFixture]
    [Category("Unittests")]
    public class FileHelperUnitTest
    {
        [TestCase("GetAgreementId", ".sql")]
        [TestCase("html2canvas", ".js")]
        public void FindLocalFile(string filename, string extension)
        {
            var pathWithFileName = FileHelper.GetPath(filename, extension);

            Assert.That(pathWithFileName, Is.Not.Null, $"file name {filename} not found");
        }
    }
}

