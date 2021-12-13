using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection_YourTransfers : HomePageFinancesSection
    {
        public HomePageFinancesSection_YourTransfers(ScenarioContext context) : base(context) { }

        public ManageTransferMatchingPage NavigateToTransferMatchingPage()
        {
            formCompletionHelper.Click(YourTransfersLink);
            return new ManageTransferMatchingPage(_context);
        }
    }
}
