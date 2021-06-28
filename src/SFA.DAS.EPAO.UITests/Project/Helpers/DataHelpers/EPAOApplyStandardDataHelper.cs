using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers
{
    public class EPAOApplyStandardDataHelper : EPAODataHelper
    {
        public EPAOApplyStandardDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator) { }

        public string ApplyStandardName => "Software developer";

        public string ApplyStandardCode => "2";

        public string StandardAssessorOrganisationEpaoId => "EPA0002";

        public string GenerateRandomAlphanumericString(int length) => randomDataGenerator.GenerateRandomAlphanumericString(length);

        public string GenerateRandomWholeNumber(int length) => randomDataGenerator.GenerateRandomWholeNumber(length);
    }
}
