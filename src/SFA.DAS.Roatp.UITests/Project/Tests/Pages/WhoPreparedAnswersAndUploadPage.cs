using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WhoPreparedAnswersAndUploadPage : RoatpBasePage
    {
        protected override string PageTitle => "Who prepared the answers and uploads in this section?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AnEmployeeInYourOrganisationCheckbox => By.Id("option_0");


        public WhoPreparedAnswersAndUploadPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectAnEmployeeInYourOrganisationOnWhoPreparedAnswersAndUploadPageAndContinue()
        {
            formCompletionHelper.ClickElement(AnEmployeeInYourOrganisationCheckbox);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
