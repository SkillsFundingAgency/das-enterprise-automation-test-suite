using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{

    public class ApplicationProcessPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How would you like to receive applications?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Yes => By.CssSelector("#application-method-faa");

        public ApplicationProcessPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public VacancyPreviewPart2Page ApplicationMethodFAA()
        {
            _formCompletionHelper.Click(Yes);
            _formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }

    }
}
