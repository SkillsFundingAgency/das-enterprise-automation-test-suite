using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class CreateVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Create vacancy";

        private By ContinueButton = By.CssSelector("[data-automation='continue-button']");
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public CreateVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public VacancyTitlePage CreateNewVacancy()
        {
            SelectRadioOptionByForAttribute("create-new");
            formCompletionHelper.Click(ContinueButton);
            return new VacancyTitlePage(_context);
        }
    }
}
