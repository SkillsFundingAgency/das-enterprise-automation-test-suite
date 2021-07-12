using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers
{
    public class EPAOApplyStandardDataHelper : EPAODataHelper
    {
        public EPAOApplyStandardDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator) { }

        public string ApplyStandardName => "Advanced butcher";

        public string ApplyStandardCode => "152";

        public string StandardAssessorOrganisationEpaoId => "EPA0002";

        public string GenerateRandomAlphanumericString(int length) => randomDataGenerator.GenerateRandomAlphanumericString(length);

        public string GenerateRandomWholeNumber(int length) => randomDataGenerator.GenerateRandomWholeNumber(length);
    }
}
