using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmRolesAndResponsibilitiesPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => SectionHelper.Section5;
        protected override By ContinueButton => By.CssSelector("#roles-responsibilities-confirm");

        public ConfirmRolesAndResponsibilitiesPage(ScenarioContext context) : base(context) => VerifyPage();

        public new ConfirmRolesAndResponsibilitiesPage VerifyRolesYourResponsibilitiesTab()
        {
            base.VerifyRolesYourResponsibilitiesTab();
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
