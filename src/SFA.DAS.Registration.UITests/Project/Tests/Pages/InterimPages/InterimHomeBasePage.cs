using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages
{
    public abstract class InterimHomeBasePage(ScenarioContext context, bool navigate) : InterimEmployerBasePage(context, navigate)
    {
        protected override string PageTitle => objectContext.GetOrganisationName();

        protected override string Linktext => "Home";
        protected override By AcceptCookieButton => By.CssSelector(".das-cookie-banner__button-accept");
    }
}