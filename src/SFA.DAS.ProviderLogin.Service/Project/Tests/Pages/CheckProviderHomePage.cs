using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckProviderHomePage(ScenarioContext context, string ukprn) : CheckPageUsingShorterTimeOut(context)
{
    protected override string PageTitle => ukprn;

    protected override By Identifier => ProviderHomePage.ProviderHomePageIdentifier;

    public override bool IsPageDisplayed() => IsPageDisplayedUsingPageTitle(ukprn);
}
