using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_RequirementsAndProspectsPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Requirements and prospects";

        private By SaveAndContinueButton => By.Id("VacancyRequirementsProspectsButton");
        private By DesiredSkillsText => By.CssSelector("iframe[title='Rich Text Editor, DesiredSkills']");
        private By PersonalQualitiesText => By.CssSelector("iframe[title='Rich Text Editor, PersonalQualities']");
        private By DesiredQualificationsText => By.CssSelector("iframe[title='Rich Text Editor, DesiredQualifications']");
        private By FutureProspectsText => By.CssSelector("iframe[title='Rich Text Editor, FutureProspects']");
        private By ThingsToConsiderText => By.CssSelector("iframe[title='Rich Text Editor, ThingsToConsider']");

        public RAA_RequirementsAndProspectsPage(ScenarioContext context) : base(context) { }

        public RAA_RequirementsAndProspectsPage EnterDesiredSkillsText()
        {
            formCompletionHelper.SendKeys(DesiredSkillsText, Keys.Tab + rAAV1DataHelper.DesiredSkills);
            return this;
        }

        public RAA_RequirementsAndProspectsPage EnterPersonalQualitiesText()
        {
            formCompletionHelper.SendKeys(PersonalQualitiesText, Keys.Tab + rAAV1DataHelper.PersonalQualities);
            return this;
        }

        public RAA_RequirementsAndProspectsPage EnterDesiredQualificationsText()
        {
            formCompletionHelper.SendKeys(DesiredQualificationsText, Keys.Tab + rAAV1DataHelper.DesiredQualifications);
            return this;
        }

        public RAA_RequirementsAndProspectsPage EnterFutureProspectsText()
        {
            formCompletionHelper.SendKeys(FutureProspectsText, Keys.Tab + rAAV1DataHelper.FutureProspects);
            return this;
        }

        public RAA_RequirementsAndProspectsPage EnterThingsToConsiderText()
        {
            formCompletionHelper.SendKeys(ThingsToConsiderText, Keys.Tab + rAAV1DataHelper.ThingsToConsider);
            return this;
        }

        public RAA_RequirementsAndProspectsPage ClickSaveAndContinue()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
            return this;
        }
    }
}
