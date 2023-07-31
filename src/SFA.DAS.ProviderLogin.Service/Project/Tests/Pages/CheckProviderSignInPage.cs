using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckProviderSignInPage : CheckPageUsingShorterTimeOut
{
    protected override By Identifier => By.Id("form-signin");

    public CheckProviderSignInPage(ScenarioContext context) : base(context) { }
}
