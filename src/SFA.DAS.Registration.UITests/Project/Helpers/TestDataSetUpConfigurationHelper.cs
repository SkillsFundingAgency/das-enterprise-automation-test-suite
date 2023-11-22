using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers;

public class TestDataSetUpConfigurationHelper
{
    private readonly ScenarioContext _context;

    public readonly string[] _tags;

    public TestDataSetUpConfigurationHelper(ScenarioContext context)
    {
        _context = context;
        _tags = _context.ScenarioInfo.Tags;
    }

    public bool NoNeedToSetUpConfiguration()
    {
        return _tags.Contains("testdatascenario") && (_tags.Contains("deletecohortviaproviderportal") || (_tags.Contains("deletecohortviaemployerportal")));
    }
}
