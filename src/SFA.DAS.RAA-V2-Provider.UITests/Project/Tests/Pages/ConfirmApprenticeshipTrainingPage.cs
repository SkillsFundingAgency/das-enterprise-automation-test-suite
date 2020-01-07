using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
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

        public ChooseNoOfPositionsPage ConfirmTrainingAndContinue()
        {
            Continue();
            return new ChooseNoOfPositionsPage(_context);
        }
    }
}
