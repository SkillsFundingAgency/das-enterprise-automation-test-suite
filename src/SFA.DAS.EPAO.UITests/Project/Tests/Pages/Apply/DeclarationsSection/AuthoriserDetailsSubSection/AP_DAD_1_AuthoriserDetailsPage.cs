using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.MandatoryExclusionSubSection;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.AuthoriserDetailsSubSection
{
    public class AP_DAD_1_AuthoriserDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Authoriser details";
        private readonly ScenarioContext _context;

        #region Locators
        private By NameTextbox => By.Id("W_DEL-01");
        private By JobTitleTextbox => By.Id("W_DEL-02");
        #endregion

        public AP_DAD_1_AuthoriserDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_DME_1_CriminalConvictionsPage EnterDetailsAndContinueInAuthoriserDetailsPagePage()
        {
            formCompletionHelper.EnterText(NameTextbox, ePAOApplyDataHelper.GetRandomAlphabeticString(20));
            formCompletionHelper.EnterText(JobTitleTextbox, ePAOApplyDataHelper.GetRandomAlphabeticString(10));
            Continue();
            return new AP_DME_1_CriminalConvictionsPage(_context);
        }
    }
}
