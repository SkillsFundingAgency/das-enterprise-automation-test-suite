using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class DesiredSkillsPage : RAAV2CSSBasePage
    {        
        protected override string PageTitle => "Which skills and personal qualities would you like the applicant to have?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly EmployerDataHelper _dataHelper;
        #endregion

        private By Skills => By.CssSelector(".govuk-checkboxes__label");

        public DesiredSkillsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<EmployerDataHelper>();
            VerifyPage();
        }

        public VacancyPreviewPart2Page SelectSkill()
        {
            _formCompletionHelper.SelectCheckBoxByText(Skills, _dataHelper.DesiredSkill);
            _formCompletionHelper.Click(Continue);
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
