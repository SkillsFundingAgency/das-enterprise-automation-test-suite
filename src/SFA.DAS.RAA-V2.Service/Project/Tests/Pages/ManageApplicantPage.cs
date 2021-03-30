using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageApplicantPage : RAAV2CSSBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        protected override string PageTitle => "About you";

        private By SaveStatus = By.CssSelector("button[type='submit'][class='govuk-button']");
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CandidateFeedback => By.CssSelector("#CandidateFeedback");

        public ManageApplicantPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAAV2CSSBasePage MakeApplicantSuccessful(bool permissionDenied = false)
        {
            SelectRadioOptionByForAttribute("outcome-successful");
            formCompletionHelper.Click(SaveStatus);

            return permissionDenied
                ? new DoNotHavePermissionBasePage(_context)
                : new ConfirmApplicantSucessfulPage(_context) as RAAV2CSSBasePage;
        }

        public RAAV2CSSBasePage MakeApplicantUnsuccessful(bool permissionDenied = false)
        {
            SelectRadioOptionByForAttribute("outcome-unsuccessful");
            formCompletionHelper.EnterText(CandidateFeedback, rAAV2DataHelper.OptionalMessage);
            formCompletionHelper.Click(SaveStatus);

            return permissionDenied
                ? new DoNotHavePermissionBasePage(_context)
                : new ConfirmApplicantUnsucessfulPage(_context) as RAAV2CSSBasePage;
        }
    }
}
