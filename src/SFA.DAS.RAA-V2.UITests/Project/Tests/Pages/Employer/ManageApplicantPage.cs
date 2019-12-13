using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ManageApplicantPage : RAAV2CSSBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        protected override string PageTitle => "About you";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ManageApplicantPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ConfirmApplicantSucessfulPage MakeApplicantSucessful()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "outcome-successful");
            _formCompletionHelper.Click(Continue);
            return new ConfirmApplicantSucessfulPage(_context);
        }
    }
}
