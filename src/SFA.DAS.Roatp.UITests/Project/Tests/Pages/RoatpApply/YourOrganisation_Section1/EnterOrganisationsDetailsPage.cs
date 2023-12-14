using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class EnterOrganisationsDetailsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Enter the organisation's details";

        private static By OrganisationDetails => By.CssSelector(".govuk-input[type='text']");

        public EnterOrganisationsDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public ConfirmPartnerShipDetailsPage EnterOrganisationDetailsAndContinue()
        {
            formCompletionHelper.EnterText(OrganisationDetails, RoatpApplyDataHelpers.FullName);
            Continue();
            return new ConfirmPartnerShipDetailsPage(context);
        }
    }
}
