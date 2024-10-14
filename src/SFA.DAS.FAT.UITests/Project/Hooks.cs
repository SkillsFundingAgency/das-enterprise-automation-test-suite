global using NUnit.Framework;
global using OpenQA.Selenium;
global using SFA.DAS.FAT.UITests.Project.Helpers;
global using SFA.DAS.FAT.UITests.Project.Tests.Pages;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.UI.Framework;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project;

[Binding]
public class Hooks(ScenarioContext context)
{
    private readonly TabHelper _tabHelper = context.Get<TabHelper>();

    [BeforeScenario(Order = 23)]
    public void NavigateToFATHomepage() => _tabHelper.GoToUrl(UrlConfig.FAT_BaseUrl);
}