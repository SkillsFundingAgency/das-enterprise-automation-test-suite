using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EmployerAgreementShutterPage : EIBasePage
    {
        protected override string PageTitle => "You need to sign a new agreement";

        #region Locators
        private readonly ScenarioContext _context;
        private By ViewAgreementButton => By.LinkText("View agreement");
        private By ReturnToAccountHomeLink => By.LinkText("Return to account home");
        #endregion

        public EmployerAgreementShutterPage(ScenarioContext context) : base(context) => _context = context;

        public YourOrganisationsAndAgreementsPage ClickOnViewAgreementButton()
        {
            formCompletionHelper.Click(ViewAgreementButton);
            return new YourOrganisationsAndAgreementsPage(_context);
        }

        public HomePage ClickOnReturnToAccountHomeLink()
        {
            formCompletionHelper.Click(ReturnToAccountHomeLink);
            return new HomePage(_context);
        }
    }
}
