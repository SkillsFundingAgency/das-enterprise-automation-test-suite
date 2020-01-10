using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
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

        public SubmitNoOfPositionsPage ConfirmTrainingProviderAndContinue()
        {
            Continue();
            return new SubmitNoOfPositionsPage(_context);
        }
    }
}
