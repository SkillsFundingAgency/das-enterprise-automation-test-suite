using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages
{
    public class ApprenticeDetailsPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
