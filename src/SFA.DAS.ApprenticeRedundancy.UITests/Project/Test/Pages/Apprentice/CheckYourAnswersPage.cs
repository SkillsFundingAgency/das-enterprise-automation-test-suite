using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.Apprentice
{
    public class CheckYourAnswersPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Check your answers";


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CheckYourAnswersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApprenticeConfirmationPage ConfirmAnswers()
        {
            Continue();
            return new ApprenticeConfirmationPage(_context);
        }
    }
}
