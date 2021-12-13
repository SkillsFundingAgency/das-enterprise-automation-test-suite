using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
   public class EnterOrganisationsDetailsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Enter the organisation's details";
        
        private By OrganisationDetails => By.CssSelector(".govuk-input[type='text']");

        public EnterOrganisationsDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public ConfirmPartnerShipDetailsPage EnterOrganisationDetailsAndContinue()
        {
            formCompletionHelper.EnterText(OrganisationDetails, applydataHelpers.FullName);
            Continue();
            return new ConfirmPartnerShipDetailsPage(_context);
        }
    }
}
