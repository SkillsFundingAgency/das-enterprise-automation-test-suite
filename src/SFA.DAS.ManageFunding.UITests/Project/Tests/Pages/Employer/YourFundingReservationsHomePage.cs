using OpenQA.Selenium;
using SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer;
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

        internal YourFundingReservationsPage OpenYourFundingReservations()
        {
            formCompletionHelper.ClickElement(YourFundingReservationsLink);
            return new YourFundingReservationsPage(_context);
        }
    }
}
