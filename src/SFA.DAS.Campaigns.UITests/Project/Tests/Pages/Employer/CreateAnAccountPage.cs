using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class CreateAnAccountPage : EmployerBasePage
    {
        protected override string PageTitle => "CREATE AN APPRENTICESHIP SERVICE ACCOUNT";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        #endregion

        private By CreateAnAccount => By.CssSelector(".button.button-employer");

        public CreateAnAccountPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
        }

        public SignInPage CreateAnAccountOnGovUk()
        {
            _tabHelper.OpenInNewTab(()=> formCompletionHelper.ClickElement(CreateAnAccount));
            return new SignInPage(_context);
        }
    }
}

