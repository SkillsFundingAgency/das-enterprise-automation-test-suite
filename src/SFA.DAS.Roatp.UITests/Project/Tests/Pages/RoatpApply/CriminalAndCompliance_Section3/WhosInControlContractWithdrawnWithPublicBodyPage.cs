using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class WhosInControlContractWithdrawnWithPublicBodyPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "withdrawn from a contract with a public body in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhosInControlContractWithdrawnWithPublicBodyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlBreachTaxSocialSecurityPage SelectYesEnterInformationForContractWithdrawnWithPublicBodyAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WhosInControlContractWithdrawnWithPublicBody);
            return new WhosInControlBreachTaxSocialSecurityPage(_context);
        }
    }
}
