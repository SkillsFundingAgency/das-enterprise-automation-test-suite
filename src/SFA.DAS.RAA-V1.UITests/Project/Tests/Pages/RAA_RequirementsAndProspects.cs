using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class RAA_RequirementsAndProspects : BasePage
    {
        protected override string PageTitle => "Requirements and prospects";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1DataHelper _dataHelper;
        #endregion

        private By SaveAndContinueButton => By.Id("VacancyRequirementsProspectsButton");
        private By DesiredSkillsText => By.XPath(".//*[@title='Rich Text Editor, DesiredSkills']");
        private By PersonalQualitiesText => By.XPath(".//*[@title='Rich Text Editor, PersonalQualities']");
        private By DesiredQualificationsText => By.XPath(".//*[@title='Rich Text Editor, DesiredQualifications']");
        private By FutureProspectsText => By.XPath(".//*[@title='Rich Text Editor, FutureProspects']");
        private By ThingsToConsiderText => By.XPath(".//*[@title='Rich Text Editor, ThingsToConsider']");

        public RAA_RequirementsAndProspects(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<RAAV1DataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public RAA_RequirementsAndProspects EnterDesiredSkillsText()
        {
            _formCompletionHelper.SendKeys(DesiredSkillsText, Keys.Tab + _dataHelper.DesiredSkills);
            return this;
        }

        public RAA_RequirementsAndProspects EnterPersonalQualitiesText()
        {
            _formCompletionHelper.SendKeys(PersonalQualitiesText, Keys.Tab + _dataHelper.PersonalQualities);
            return this;
        }

        public RAA_RequirementsAndProspects EnterDesiredQualificationsText()
        {
            _formCompletionHelper.SendKeys(DesiredQualificationsText, Keys.Tab + _dataHelper.DesiredQualifications);
            return this;
        }

        public RAA_RequirementsAndProspects EnterFutureProspectsText()
        {
            _formCompletionHelper.SendKeys(FutureProspectsText, Keys.Tab + _dataHelper.FutureProspects);
            return this;
        }

        public RAA_RequirementsAndProspects EnterThingsToConsiderText()
        {
            _formCompletionHelper.SendKeys(ThingsToConsiderText, Keys.Tab + _dataHelper.ThingsToConsider);
            return this;
        }

        public RAA_RequirementsAndProspects ClickSaveAndContinue()
        {
            _formCompletionHelper.Click(SaveAndContinueButton);
            return this;
        }
    }
}
