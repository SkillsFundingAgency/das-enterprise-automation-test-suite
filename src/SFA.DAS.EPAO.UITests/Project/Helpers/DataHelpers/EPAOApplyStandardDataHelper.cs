using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers
{
    public class EPAOApplyStandardDataHelper : EPAODataHelper
    {
        public EPAOApplyStandardDataHelper() : base() { }

        public string ApplyStandardName => "Advanced butcher";

        public string ApplyStandardCode => "152";

        public string StandardAssessorOrganisationEpaoId => "EPA0002";

        public string GenerateRandomAlphanumericString(int length) => RandomDataGenerator.GenerateRandomAlphanumericString(length);

        public string GenerateRandomWholeNumber(int length) => RandomDataGenerator.GenerateRandomWholeNumber(length);
    }
}
