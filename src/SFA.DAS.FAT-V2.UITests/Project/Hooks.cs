global using NUnit.Framework;
global using TechTalk.SpecFlow;
global using OpenQA.Selenium;
global using SFA.DAS.UI.Framework;
global using SFA.DAS.UI.FrameworkHelpers;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FAT_V2.UITests.Project.Tests.Pages;
global using SFA.DAS.FAT_V2.UITests.Project.Helpers;
global using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FAT_V2.UITests.Project;

[Binding]
public class Hooks
{
    private readonly TabHelper _tabHelper;

    public Hooks(ScenarioContext context) => _tabHelper = context.Get<TabHelper>();

    [BeforeScenario(Order = 21)]
    public void NavigateToFATHomepage() => _tabHelper.GoToUrl(UrlConfig.FATV2_BaseUrl);
}