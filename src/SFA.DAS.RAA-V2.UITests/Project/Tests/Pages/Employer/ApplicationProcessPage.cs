using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{

    public class ApplicationProcessPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How would you like to receive applications?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By Yes => By.CssSelector("#application-method-faa");

        public ApplicationProcessPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public VacancyPreviewPart2Page ApplicationMethodFAA()
        {
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(Yes));
            _formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
