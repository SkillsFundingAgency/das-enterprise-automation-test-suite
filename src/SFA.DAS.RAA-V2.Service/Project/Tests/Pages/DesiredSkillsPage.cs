using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class DesiredSkillsPage : RAAV2CSSBasePage
    {        
        protected override string PageTitle => "What skills and personal qualities would you like the applicant to have?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Skills => By.CssSelector("label.govuk-checkboxes__label");

        private  By SaveAndContinue => By.CssSelector(".save-button[data-automation='btn-continue']");

        public DesiredSkillsPage(ScenarioContext context) : base(context) => _context = context;

        public VacancyPreviewPart2Page SelectSkill()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(Skills)));

            formCompletionHelper.Click(SaveAndContinue);

            return new VacancyPreviewPart2Page(_context);
        }
    }
}
