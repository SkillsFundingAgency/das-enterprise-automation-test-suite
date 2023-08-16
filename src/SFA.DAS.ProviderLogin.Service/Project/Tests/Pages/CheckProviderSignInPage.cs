using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckProviderSignInPage : CheckPageUsingShorterTimeOut
{
    //pas login changes
    //protected override By Identifier => By.Id("form-signin");

    protected override By Identifier => By.Id("sfaLogin");

    public CheckProviderSignInPage(ScenarioContext context) : base(context) { }
}
