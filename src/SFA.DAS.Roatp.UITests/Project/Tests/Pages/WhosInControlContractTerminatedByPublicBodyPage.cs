using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WhosInControlContractTerminatedByPublicBodyPage : RoatpBasePage
    {
        protected override string PageTitle => "had a contract terminated by a public body in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_WhosInControlContractTerminatedByPublicBodyOrganisations => By.Id("CC-80.1");

        private By LongTextArea_WhosInControlContractTerminatedByPublicBodySoleTrader => By.Id("CC-81.1");

        public WhosInControlContractTerminatedByPublicBodyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlContractWithdrawnWithPublicBodyPage SelectYesEnterInformationForContractTerminatedByPublicBodyAndContinue()
        {
            SelectRadioOptionByText("Yes");
            var field = pageInteractionHelper.IsElementDisplayed(LongTextArea_WhosInControlContractTerminatedByPublicBodyOrganisations) ? LongTextArea_WhosInControlContractTerminatedByPublicBodyOrganisations : LongTextArea_WhosInControlContractTerminatedByPublicBodySoleTrader;
            formCompletionHelper.EnterText(field, applydataHelpers.WhosInControlContractTerminatedByPublicBody);
            Continue();
            return new WhosInControlContractWithdrawnWithPublicBodyPage(_context);
        }
    }
}
