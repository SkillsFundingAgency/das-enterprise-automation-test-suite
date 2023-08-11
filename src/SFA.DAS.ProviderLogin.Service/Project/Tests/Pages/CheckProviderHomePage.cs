using OpenQA.Selenium;
using SFA.DAS.IdamsLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;

public class CheckProviderPireanPreprodPage : CheckPageUsingShorterTimeOut
{
    protected override string PageTitle { get; }

    protected override By Identifier => IdamsPageSelector.PireanPreprod;

    public By PireanPreprod => Identifier;

    public CheckProviderPireanPreprodPage(ScenarioContext context) : base(context) { }
}

public class CheckProviderHomePage : CheckPageUsingShorterTimeOut
{
    protected override string PageTitle { get; }

        protected override By Identifier => ProviderHomePage.Identifier;

        public CheckProviderHomePage(ScenarioContext context) : base(context) { }

        public bool IsPageDisplayed(string ukprn) => IsPageDisplayed(() => checkPageInteractionHelper.VerifyPage(Identifier, ukprn));
}
