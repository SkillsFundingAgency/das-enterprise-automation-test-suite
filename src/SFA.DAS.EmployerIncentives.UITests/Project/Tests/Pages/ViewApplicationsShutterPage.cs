using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ViewApplicationsShutterPage : EIBasePage
    {
        protected override string PageTitle => "Your hire a new apprentice payment applications";

        #region Locators
        private readonly ScenarioContext _context;
        private By ApplyForThePaymentLink => By.LinkText("apply for the payment");
        #endregion

        public ViewApplicationsShutterPage(ScenarioContext context) : base(context) => _context = context;

        public EIStartPage ClickOnApplyForThePaymentLink()
        {
            formCompletionHelper.Click(ApplyForThePaymentLink);
            return new EIStartPage(_context);
        }
    }
}
