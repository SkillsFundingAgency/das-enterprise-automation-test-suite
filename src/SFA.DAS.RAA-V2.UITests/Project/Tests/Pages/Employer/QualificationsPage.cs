using OpenQA.Selenium;
using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class QualificationsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "What qualifications would you like the applicant to have?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By QualificationType => By.CssSelector("#QualificationType");

        private By Subject => By.CssSelector("#Subject");

        private By Grade => By.CssSelector("#Grade");

        
        public QualificationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public ConfirmQualificationsPage EnterQualifications()
        {
            _formCompletionHelper.SelectFromDropDownByText(QualificationType, "A Level or equivalent");
            _formCompletionHelper.EnterText(Subject, _dataHelper.DesiredQualificationsSubject);
            _formCompletionHelper.EnterText(Grade, _dataHelper.DesiredQualificationsGrade);
            _formCompletionHelper.ClickElement(() => _dataHelper.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(RadioLabels)));
            _formCompletionHelper.Click(Continue);
            return new ConfirmQualificationsPage(_context);
        }

    }
}
