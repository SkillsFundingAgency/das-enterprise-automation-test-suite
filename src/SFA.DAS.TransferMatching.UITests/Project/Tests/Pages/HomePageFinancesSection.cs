using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection_YourTransfers : HomePageFinancesSection
    {
        private readonly ScenarioContext _context;

        public HomePageFinancesSection_YourTransfers(ScenarioContext context) : base(context) => _context = context;

        public TransferMatchingPage NavigateToTransferMatchingPage()
        {
            formCompletionHelper.Click(YourTransfersLink);
            return new TransferMatchingPage(_context);
        }
    }
}
