using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class TransactionCompletePage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "You have confirmed your apprenticeship";
        private readonly ScenarioContext _context;

        protected By TrainingName => By.CssSelector(".govuk-panel__body");

        public TransactionCompletePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(TrainingName, objectContext.GetTrainingName().Split(",")[0]);
        }

        public ApprenticeHomePage NavigateBackToOverviewPage()
        {
            NavigateBack();
            return new ApprenticeHomePage(_context);
        }
    }
}
