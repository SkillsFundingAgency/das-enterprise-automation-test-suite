using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmTrainingProviderPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Confirm the training provider";

        #region Helpers and Context
        private readonly ScenarioContext _context;

        #endregion

        public ConfirmTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ChooseNoOfPositionsPage ConfirmTrainingProviderAndContinue()
        {
            Continue();
            return new ChooseNoOfPositionsPage(_context);
        }
    }
}
