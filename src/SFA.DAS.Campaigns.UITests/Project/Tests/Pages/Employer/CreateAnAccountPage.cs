using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class CreateAnAccountPage : EmployerBasePage
    {
        protected override string PageTitle => "CREATE AN APPRENTICESHIP SERVICE ACCOUNT";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CreateAnAccount => By.CssSelector(".button.button-employer");

        public CreateAnAccountPage(ScenarioContext context) : base(context) => _context = context;

        public SignInPage CreateAnAccountOnGovUk()
        {
            tabHelper.OpenInNewTab(()=> formCompletionHelper.ClickElement(CreateAnAccount));
            return new SignInPage(_context);
        }
    }
}

