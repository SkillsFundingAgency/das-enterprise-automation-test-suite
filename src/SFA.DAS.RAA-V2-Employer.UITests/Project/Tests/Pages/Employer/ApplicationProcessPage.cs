using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{

    public class ApplicationProcessPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How would you like to receive applications?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By Yes => By.CssSelector("#application-method-faa");

        private By ApplicationUrl => By.CssSelector("#ApplicationUrl");

        private By ApplicationInstructions => By.CssSelector("#ApplicationInstructions");

        public ApplicationProcessPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public VacancyPreviewPart2Page ApplicationMethod(bool isFAA) => isFAA ? ApplicationMethodFAA() : ApplicationMethodExternal();

        private VacancyPreviewPart2Page ApplicationMethodFAA()
        {
            formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(Yes));
            return SaveAndContinue();
        }

        private VacancyPreviewPart2Page ApplicationMethodExternal()
        {
            SelectRadioOptionByForAttribute("application-method-external");
            formCompletionHelper.EnterText(ApplicationUrl, dataHelper.EmployerWebsiteUrl);
            formCompletionHelper.EnterText(ApplicationInstructions, dataHelper.OptionalMessage);
            return SaveAndContinue();
        }

        private VacancyPreviewPart2Page SaveAndContinue()
        {
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
