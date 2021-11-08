using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class TransferMatchingPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Transfers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TransferMatchingPage(ScenarioContext context) : base(context) => _context = context;


    }
}