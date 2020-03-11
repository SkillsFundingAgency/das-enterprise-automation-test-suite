using TechTalk.SpecFlow;

namespace SFA.DAS.ASK.UITests.Project.Tests.Pages
{
    public class YourDetailsPage : AskBasePage
    {
        protected override string PageTitle => "Your details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public YourDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
