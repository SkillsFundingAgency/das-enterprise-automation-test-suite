using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.Pages
{
    public class YourFundingReservationsPage : InterimBasePage
    {
        protected override string Linktext => "Finance";

        protected override string PageTitle => "Finance";

        private ScenarioContext _context;

        private By YourFundingReservationsLink => By.LinkText("Your funding reservations");

        public YourFundingReservationsPage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            VerifyPage();
        }

        internal YourFundingReservationsPage OpenYourFundingReservations()
        {
            formCompletionHelper.ClickElement(YourFundingReservationsLink);
            return new YourFundingReservationsPage(_context);
        }
    }
}
