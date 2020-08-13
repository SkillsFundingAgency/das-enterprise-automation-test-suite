using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class YouCannotApplyForThisGrantYetPage : EIBasePage
    {
        protected override string PageTitle => "You cannot apply for this grant yet?";

        #region Locators
        private readonly ScenarioContext _context;
        private By AddApprenticesLink => By.LinkText("add them to your apprenticeship service account.");
        #endregion

        public YouCannotApplyForThisGrantYetPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticesHomePage ClickOnAddApprenticesLink()
        {
            formCompletionHelper.Click(AddApprenticesLink);
            return new ApprenticesHomePage(_context);
        }

        public HaveYouTakenOnNewApprenticesPage NavigateBrowserBack()
        {
            tabHelper.NavigateBrowserBack();
            return new HaveYouTakenOnNewApprenticesPage(_context);
        }
    }
}
