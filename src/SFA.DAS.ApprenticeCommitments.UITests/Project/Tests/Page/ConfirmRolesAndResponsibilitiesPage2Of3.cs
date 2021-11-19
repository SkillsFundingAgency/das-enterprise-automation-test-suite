using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmRolesAndResponsibilitiesPage2of3 : ConfirmYourDetailsPage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Your employer’s responsibilities";
        protected override By ContinueButton => By.CssSelector("#roles-responsibilities-confirm");

        public ConfirmRolesAndResponsibilitiesPage2of3(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmRolesAndResponsibilitiesPage3of3 ConfirmEmployerRolesAndContinue()
        {
            SelectCheckBoxAndContinue();
            return new ConfirmRolesAndResponsibilitiesPage3of3(_context);
        }
    }
}
