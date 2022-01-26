using System;
using NUnit.Framework;
using System.IO;

namespace SFA.DAS.FrameworkHelpers
{
    public class TestAttachmentHelper
    {
        public static void AddTestAttachment(string directoryPath, string fileName, Action<string> action)
        {
            string filePath = Path.Combine(directoryPath, fileName);

            action(filePath);

            TestContext.AddTestAttachment(filePath, fileName);
        }
    }
}