using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class DesiredSkillsPage : Raav2BasePage
    {
        protected override string PageTitle => "What skills and personal qualities do applicants need to have?";

        private By Skills => By.CssSelector("label.govuk-checkboxes__label");

        private By SaveAndContinue => By.CssSelector(".save-button[data-automation='btn-continue']");

        public DesiredSkillsPage(ScenarioContext context) : base(context) { }

        public PreviewYourAdvertOrVacancyPage SelectSkill()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(Skills)));

            formCompletionHelper.Click(SaveAndContinue);

            return new PreviewYourAdvertOrVacancyPage(context);
        }

        public QualificationsPage SelectSkillAndGoToQualificationsPage()
        {
            formCompletionHelper.ClickElement(() => RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(Skills)));

            formCompletionHelper.Click(SaveAndContinue);

            return new QualificationsPage(context);
        }
    }
}
