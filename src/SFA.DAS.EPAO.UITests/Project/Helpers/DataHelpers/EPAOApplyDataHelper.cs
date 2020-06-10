using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers
{
    public class EPAOApplyDataHelper : EPAODataHelper
    {
        public EPAOApplyDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator) { }

        public string InvalidOrgNameWithAlphabets => "asfasfasdfasdf";
        public string InvalidOrgNameWithNumbers => "54678900";
        public string InvalidOrgNameWithAWord => "EPA01";
    }
}
