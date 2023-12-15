using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers;

public class TestDataSetUpConfigurationHelper(ScenarioContext context)
{
    public readonly string[] _tags = context.ScenarioInfo.Tags;

    public bool NoNeedToSetUpConfiguration()
    {
        return _tags.Contains("testdatascenario") && (_tags.Contains("deletecohortviaproviderportal") || _tags.Contains("deletecohortviaemployerportal") || _tags.Contains("addmultiplelevyfunds"));
    }
}
