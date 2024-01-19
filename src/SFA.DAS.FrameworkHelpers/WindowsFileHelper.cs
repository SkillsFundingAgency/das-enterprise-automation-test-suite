using NUnit.Framework;
using System.IO;

namespace SFA.DAS.FrameworkHelpers
{
    public class WindowsFileHelper
    {
        private readonly int limitedWinChar;

        public WindowsFileHelper() : this(250) { }

        internal WindowsFileHelper(int x) => limitedWinChar = x;

        public (string fullPath, string fileName) GetFileDetails(string directory, string fileName)
        {
            fileName = EscapePatternHelper.FileEscapePattern(fileName);

            var fullPath = Combine(directory, fileName);

            var noOfChar = fullPath.Length;

            if (noOfChar > limitedWinChar)
            {
                var fileSplit = fileName.Split(".");

                var fileNamewithoutextension = fileSplit[0];

                var extension = fileSplit[1];

                int excessChar = noOfChar - limitedWinChar;

                fileNamewithoutextension = $"{fileNamewithoutextension[..^excessChar]}";

                fileName = $"{fileNamewithoutextension}.{extension}";

                fullPath = Combine(directory, fileName);
            }

            return (fullPath, fileName);
        }

        private static string Combine(string directory, string imageName)
        {
            var path = Path.Combine(directory, imageName);

            return Path.GetFullPath(path);
        }
    }

    [TestFixture]
    [Category("Unittests")]
    public class TestWindowsFileHelper
    {
        [TestCase(24, "c:\\directoryname", "image.png", "c:\\directoryname\\ima.png")]
        [TestCase(24, "c:\\directoryname", "html.html", "c:\\directoryname\\ht.html")]
        [TestCase(26, "c:\\directoryname", "image.png", "c:\\directoryname\\image.png")]
        [TestCase(30, "c:\\directoryname", "html.html", "c:\\directoryname\\html.html")]
        [TestCase(30, "c:\\directoryname", "html?.html", "c:\\directoryname\\html.html")]
        [TestCase(30, "c:\\directoryname", "h\\t/m:l?h*t\"m<l>h|tml.html", "c:\\directoryname\\htmlhtml.html")]
        [TestCase(40, "c:\\directoryname", "h\\t/m:l?h*t\"m<l>h|tml.html", "c:\\directoryname\\htmlhtmlhtml.html")]
        public void TestGetFilePath(int limitedWinChar, string directory, string fileName, string expectedfullpath)
        {
            var w = new WindowsFileHelper(limitedWinChar);

            (string actualfullPath, string _) = w.GetFileDetails(directory, fileName);

            Assert.AreEqual(expectedfullpath, actualfullPath);
        }
    }
}