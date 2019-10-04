using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.Pages
{
    public class YourFundingReservationsHomePage : HomePage
    {
        private ScenarioContext _context;

        private By YourFundingReservationsLink => By.LinkText("Your funding reservations");

        public YourFundingReservationsHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        internal YourFundingReservationsHomePage OpenYourFundingReservations()
        {
            formCompletionHelper.ClickElement(YourFundingReservationsLink);
            return new YourFundingReservationsHomePage(_context);
        }
    }
}
