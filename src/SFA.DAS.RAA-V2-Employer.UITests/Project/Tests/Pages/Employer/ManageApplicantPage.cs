using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Common;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class ManageApplicantPage : RAAV2CSSBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        protected override string PageTitle => "About you";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CandidateFeedback => By.CssSelector("#CandidateFeedback");

        public ManageApplicantPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ConfirmApplicantSucessfulPage MakeApplicantSucessful()
        {
            SelectRadioOptionByForAttribute("outcome-successful");
            Continue();
            return new ConfirmApplicantSucessfulPage(_context);
        }

        public ConfirmApplicantUnsucessfulPage MakeApplicantUnsucessful()
        {
            SelectRadioOptionByForAttribute("outcome-unsuccessful");
            formCompletionHelper.EnterText(CandidateFeedback, dataHelper.OptionalMessage);
            Continue();
            return new ConfirmApplicantUnsucessfulPage(_context);
        }
    }
}
