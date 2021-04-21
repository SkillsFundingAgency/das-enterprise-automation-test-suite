using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmRolesAndResponsibilitiesPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Roles and responsibilities";
        protected override By ContinueButton => By.CssSelector("#roles-responsibilities-confirm");

        public ConfirmRolesAndResponsibilitiesPage(ScenarioContext context) : base(context) => VerifyPage();

        public new ConfirmRolesAndResponsibilitiesPage VerifyRolesYouTab()
        {
            base.VerifyRolesYouTab();
            return this;
        }

        public new ConfirmRolesAndResponsibilitiesPage VerifyRolesYourEmployerTab()
        {
            base.VerifyRolesYourEmployerTab();
            return this;
        }

        public new ConfirmRolesAndResponsibilitiesPage VerifyRolesYourTrainingProviderTab()
        {
            base.VerifyRolesYourTrainingProviderTab();
            return this;
        }
    }
}
