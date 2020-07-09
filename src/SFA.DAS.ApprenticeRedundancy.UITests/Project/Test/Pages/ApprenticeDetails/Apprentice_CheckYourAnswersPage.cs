using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.Apprentice
{
    public class Apprentice_CheckYourAnswersPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Check your answers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public Apprentice_CheckYourAnswersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApprenticeConfirmationPage ConfirmApprenticeAnswers()
        {
            Continue();
            return new ApprenticeConfirmationPage(_context);
        }
    }
}
