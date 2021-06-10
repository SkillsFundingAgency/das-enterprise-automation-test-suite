using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public class CheckYourAnswersPage : AEDBasePage
    {
        protected override string PageTitle => "Check your answers";
        private readonly ScenarioContext _context;
        public CheckYourAnswersPage(ScenarioContext context) : base(context) => _context = context;

        private By Confirm => By.Id("submit-demand");


        public WeSharedThisInterestWithTrainingProvidersPage ConfirmYourAnswers()
        {
            formCompletionHelper.Click(Confirm);
            return new WeSharedThisInterestWithTrainingProvidersPage(_context);
        }
    }
}
