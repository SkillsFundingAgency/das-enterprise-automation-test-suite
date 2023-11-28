using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers;

public class TestDataSetUpConfigurationHelper
{
    public readonly string[] _tags;

    public TestDataSetUpConfigurationHelper(ScenarioContext context) => _tags = context.ScenarioInfo.Tags;

    public bool NoNeedToSetUpConfiguration()
    {
        return _tags.Contains("testdatascenario") && (_tags.Contains("deletecohortviaproviderportal") || _tags.Contains("deletecohortviaemployerportal") || _tags.Contains("addmultiplelevyfunds"));
    }
}
