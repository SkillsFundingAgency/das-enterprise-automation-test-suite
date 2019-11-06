using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_OppurtunityPreviewPage : RAA_PreviewBasePage
    {
        protected override string PageTitle => "Opportunity preview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RAA_OppurtunityPreviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }
    }
}
