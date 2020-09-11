using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class SelectApprenticesShutterPage : EIBasePage
    {
        protected override string PageTitle => "You cannot apply for this payment";

        #region Locators
        private readonly ScenarioContext _context;
        private By AddApprenticesLink => By.LinkText("add them to your apprenticeship service account.");
        #endregion

        public SelectApprenticesShutterPage(ScenarioContext context) : base(context) => _context = context;

        public AddAnApprenitcePage ClickOnAddApprenticesLink()
        {
            formCompletionHelper.Click(AddApprenticesLink);
            return new AddAnApprenitcePage(_context);
        }
    }
}
