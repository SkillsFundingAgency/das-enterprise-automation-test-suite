using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckProviderHomePage(ScenarioContext context) : CheckPageUsingShorterTimeOut(context)
{
    protected override string PageTitle { get; }

    protected override By Identifier => ProviderHomePage.Identifier;

    public bool IsPageDisplayed(string ukprn) => IsPageDisplayed(() => checkPageInteractionHelper.VerifyPage(Identifier, ukprn));
}
