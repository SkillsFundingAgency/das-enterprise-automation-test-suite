using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAOAdminDataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public EPAOAdminDataHelper(RandomDataGenerator randomDataGenerator) => _randomDataGenerator = randomDataGenerator;

        public string OrganisationName => "City and Guilds";

        public string OrganisationEpaoId => "EPA0008";

        public string OrganisationUkprn => "10009931";

        public string BatchSearch => "110";

        public string LearnerUln => "7278214419";

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> options) => _randomDataGenerator.GetRandomElementFromListOfElements(options);

    }
}
