using OpenQA.Selenium;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public class CheckYourAnswersPage : AEDBasePage
    {
        protected override string PageTitle => "Check your answers";
        private readonly ScenarioContext _context;
        public CheckYourAnswersPage(ScenarioContext context) : base(context) => _context = context;

        private By Confirm => By.Id("submit-demand");

        public EmailVerificationPage ConfirmYourAnswers()
        {
            formCompletionHelper.Click(Confirm);
            return new EmailVerificationPage(_context);
        }
    }
}
