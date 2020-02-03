using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class OtherWaysToSupportApprenticesPage : RoatpBasePage
    {
        protected override string PageTitle => "What other ways will your organisation use to support its apprentices?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_OtherWaysToSupportApprentices => By.Id("PAT-632");

        public OtherWaysToSupportApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextForOtherWaysToSupportApprenticesAndContinue()
        {
            formCompletionHelper.EnterText(LongTextArea_OtherWaysToSupportApprentices, applydataHelpers.OtherWaysToSupportApprentices);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}


