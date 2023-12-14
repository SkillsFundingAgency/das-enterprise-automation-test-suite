using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckProviderIndexPage(ScenarioContext context) : CheckPageUsingShorterTimeOut(context)
{
    protected override string PageTitle { get; }

    protected override By Identifier => ProviderIndexPage.ProviderIndexStartSelector;
}
