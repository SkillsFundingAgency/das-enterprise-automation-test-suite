using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourFundingReservationsHomePage : HomePage
    {
        protected override string PageTitle => "Your funding reservations";
        private By YourFundingReservationsLink => By.LinkText("Your funding reservations");
        private ScenarioContext _context;

        public YourFundingReservationsHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        internal YourFundingReservationsPage OpenYourFundingReservations()
        {
            formCompletionHelper.ClickElement(YourFundingReservationsLink);
            return new YourFundingReservationsPage(_context);
        }

        public YourFundingReservationsHomePage IsPageDisplayed()
        {
            return this;
        }
    }
}
