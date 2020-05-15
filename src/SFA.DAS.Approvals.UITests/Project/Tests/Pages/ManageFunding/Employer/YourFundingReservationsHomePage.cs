using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourFundingReservationsHomePage : HomePage
    {
        private readonly ScenarioContext _context;

        public YourFundingReservationsHomePage(ScenarioContext context) : base(context) => _context = context;

        internal YourFundingReservationsPage OpenYourFundingReservations()
        {
            formCompletionHelper.ClickLinkByText("Your funding reservations");
            return new YourFundingReservationsPage(_context);
        }
    }
}
