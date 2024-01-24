using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckProviderLandingPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => ProviderLandingPage.ProviderLandingPageTitle;

    protected override By Identifier => ProviderLandingPage.ProviderLandingPageIdentifier;
}
