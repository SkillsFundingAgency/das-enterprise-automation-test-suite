using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmRolesAndResponsibilitiesPage3of3 : ConfirmYourDetailsPage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Your training provider’s responsibilities";
        protected override By ContinueButton => By.CssSelector("#roles-responsibilities-confirm");

        public ConfirmRolesAndResponsibilitiesPage3of3(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AlreadyConfirmedRolesAndResponsibilitiesPage ConfirmTrainingProviderRolesAndContinue()
        {
            SelectCheckBoxAndContinue();
            return new AlreadyConfirmedRolesAndResponsibilitiesPage(_context);
        }
    }
}
