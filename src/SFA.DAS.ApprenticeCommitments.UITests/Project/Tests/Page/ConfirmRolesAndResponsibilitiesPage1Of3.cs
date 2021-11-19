using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmRolesAndResponsibilitiesPage1of3 : ConfirmYourDetailsPage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Your responsibilities as an apprentice";
        protected override By ContinueButton => By.CssSelector("#roles-responsibilities-confirm");

        public ConfirmRolesAndResponsibilitiesPage1of3(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmRolesAndResponsibilitiesPage2of3 ConfirmYourRolesAndContinue()
        {
            SelectCheckBoxAndContinue();
            return new ConfirmRolesAndResponsibilitiesPage2of3(_context);
        }
    }
}
