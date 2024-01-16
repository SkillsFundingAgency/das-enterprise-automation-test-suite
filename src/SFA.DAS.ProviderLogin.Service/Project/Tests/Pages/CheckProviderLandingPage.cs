using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckProviderLandingPage(ScenarioContext context) : CheckPageUsingShorterTimeOut(context)
{
    protected override string PageTitle { get; }

    protected override By Identifier => ProviderLandingPage.ProviderLandingPageStartSelector;
}
