using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class OrganisationHasBeenAddedPage : InterimEmployerBasePage
    {
        protected override string PageTitle => objectContext.GetOrganisationName() + " has been added";

        #region Locators
        protected override By PageHeader => By.CssSelector("h1");
        protected override string Linktext => "Home";
        #endregion

        public OrganisationHasBeenAddedPage(ScenarioContext context, bool navigate = false) : base(context, navigate) => VerifyPage();
    }
}
