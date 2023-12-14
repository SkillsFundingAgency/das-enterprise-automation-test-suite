using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckProviderSignInPage(ScenarioContext context) : CheckPageUsingShorterTimeOut(context)
{
    protected override By Identifier => By.Id("form-signin");
}
