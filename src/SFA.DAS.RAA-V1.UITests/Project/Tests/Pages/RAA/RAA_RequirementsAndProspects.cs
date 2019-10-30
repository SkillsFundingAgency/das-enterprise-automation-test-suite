using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_RequirementsAndProspects : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Requirements and prospects";

        private By SaveAndContinueButton => By.Id("VacancyRequirementsProspectsButton");
        private By DesiredSkillsText => By.CssSelector("iframe[title='Rich Text Editor, DesiredSkills']");
        private By PersonalQualitiesText => By.CssSelector("iframe[title='Rich Text Editor, PersonalQualities']");
        private By DesiredQualificationsText => By.CssSelector("iframe[title='Rich Text Editor, DesiredQualifications']");
        private By FutureProspectsText => By.CssSelector("iframe[title='Rich Text Editor, FutureProspects']");
        private By ThingsToConsiderText => By.CssSelector("iframe[title='Rich Text Editor, ThingsToConsider']");

        public RAA_RequirementsAndProspects(ScenarioContext context) : base(context) { }

        public RAA_RequirementsAndProspects EnterDesiredSkillsText()
        {
            formCompletionHelper.SendKeys(DesiredSkillsText, Keys.Tab + dataHelper.DesiredSkills);
            return this;
        }

        public RAA_RequirementsAndProspects EnterPersonalQualitiesText()
        {
            formCompletionHelper.SendKeys(PersonalQualitiesText, Keys.Tab + dataHelper.PersonalQualities);
            return this;
        }

        public RAA_RequirementsAndProspects EnterDesiredQualificationsText()
        {
            formCompletionHelper.SendKeys(DesiredQualificationsText, Keys.Tab + dataHelper.DesiredQualifications);
            return this;
        }

        public RAA_RequirementsAndProspects EnterFutureProspectsText()
        {
            formCompletionHelper.SendKeys(FutureProspectsText, Keys.Tab + dataHelper.FutureProspects);
            return this;
        }

        public RAA_RequirementsAndProspects EnterThingsToConsiderText()
        {
            formCompletionHelper.SendKeys(ThingsToConsiderText, Keys.Tab + dataHelper.ThingsToConsider);
            return this;
        }

        public RAA_RequirementsAndProspects ClickSaveAndContinue()
        {
            formCompletionHelper.Click(SaveAndContinueButton);
            return this;
        }
    }
}
