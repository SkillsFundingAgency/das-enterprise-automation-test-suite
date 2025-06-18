using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class EnterIndividualsDetailsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Enter the individual's details";

        private static By IndividualsDetails => By.CssSelector(".govuk-input[type='text']");

        public EnterIndividualsDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        protected void EnterMonthAndYear()
        {
            formCompletionHelper.EnterText(Month, "02");
            formCompletionHelper.EnterText(Year, "1991");
            Continue();
        }

        public ConfirmPartnerShipDetailsPage EnterIndividualsDetailsAndContinue()
        {
            formCompletionHelper.EnterText(IndividualsDetails, RoatpApplyDataHelpers.FullName);
            EnterMonthAndYear();
            return new ConfirmPartnerShipDetailsPage(context);
        }
    }
}
