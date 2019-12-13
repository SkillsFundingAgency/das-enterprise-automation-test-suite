using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApprenticeshipTrainingPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Confirm apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;

        #endregion

        public ConfirmApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ChooseTrainingProviderPage ConfirmTrainingAndContinue()
        {
            _formCompletionHelper.Click(Continue);
            return new ChooseTrainingProviderPage(_context);
        }
    }
}
