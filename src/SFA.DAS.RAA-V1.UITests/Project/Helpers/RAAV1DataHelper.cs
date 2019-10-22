using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class RAAV1DataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public RAAV1DataHelper(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            EmployerDescription = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerReason = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerBody = _randomDataGenerator.GenerateRandomAlphabeticString(25);
            EmployerWebsiteUrl = $"https://www.{EmployerDescription}.com";
        }

        public string EmployerDescription { get; }

        public string EmployerReason { get; }

        public string EmployerBody { get; }
        
        public string EmployerWebsiteUrl { get; }

        
    }
}

