using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class EnterIndividualsDetailsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Enter the individual's details";
        
        private By IndividualsDetails => By.CssSelector(".govuk-input[type='text']"); 

        public EnterIndividualsDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        protected void EnterMonthAndYear()
        {
            formCompletionHelper.EnterText(Month, "02");
            formCompletionHelper.EnterText(Year, "1991");
            Continue();
        }

        public ConfirmPartnerShipDetailsPage EnterIndividualsDetailsAndContinue()
        {
            formCompletionHelper.EnterText(IndividualsDetails, applydataHelpers.FullName);
            EnterMonthAndYear();
            return new ConfirmPartnerShipDetailsPage(_context);
        }
    }
}
