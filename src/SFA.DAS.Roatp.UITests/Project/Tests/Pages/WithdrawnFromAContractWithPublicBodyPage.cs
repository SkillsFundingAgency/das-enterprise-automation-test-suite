using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WithdrawnFromAContractWithPublicBodyPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation withdrawn from a contract with a public body in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion


        private By LongTextArea_WithdrawnFromAContractWithPublicBody => By.Id("CC-23.1");

        public WithdrawnFromAContractWithPublicBodyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FundingRemovedFromEducationBodiesPage SelectYesEnterInformationForContractWithdrawnWithPublicBody()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(LongTextArea_WithdrawnFromAContractWithPublicBody, applydataHelpers.WithdrawnFromAContractWithPublicBody);
            Continue();
            return new FundingRemovedFromEducationBodiesPage(_context);
        }
    }
}