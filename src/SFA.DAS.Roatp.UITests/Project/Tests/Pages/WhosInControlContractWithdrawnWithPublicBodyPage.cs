using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WhosInControlContractWithdrawnWithPublicBodyPage : RoatpBasePage
    {
        protected override string PageTitle => "withdrawn from a contract with a public body in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_WhosInControlContractWithdrawnWithPublicBodyOrganisations => By.Id("CC-90.1");

        private By LongTextArea_WhosInControlContractWithdrawnWithPublicBodySoleTrader => By.Id("CC-91.1");

        public WhosInControlContractWithdrawnWithPublicBodyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlBreachTaxSocialSecurityPage SelectYesEnterInformationForContractWithdrawnWithPublicBodyAndContinue()
        {
            SelectRadioOptionByText("Yes");
            var field = pageInteractionHelper.IsElementDisplayed(LongTextArea_WhosInControlContractWithdrawnWithPublicBodyOrganisations) ? LongTextArea_WhosInControlContractWithdrawnWithPublicBodyOrganisations : LongTextArea_WhosInControlContractWithdrawnWithPublicBodySoleTrader;
            formCompletionHelper.EnterText(field, applydataHelpers.WhosInControlContractWithdrawnWithPublicBody);
            Continue();
            return new WhosInControlBreachTaxSocialSecurityPage(_context);
        }
    }
}
