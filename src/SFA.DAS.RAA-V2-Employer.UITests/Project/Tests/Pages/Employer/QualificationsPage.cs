using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
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
            formCompletionHelper.SelectFromDropDownByText(QualificationType, "A Level or equivalent");
            formCompletionHelper.EnterText(Subject, dataHelper.DesiredQualificationsSubject);
            formCompletionHelper.EnterText(Grade, dataHelper.DesiredQualificationsGrade);
            formCompletionHelper.ClickElement(() => dataHelper.GetRandomElementFromListOfElements(_pageInteractionHelper.FindElements(RadioLabels)));
            Continue();
            return new ConfirmQualificationsPage(_context);
        }

    }
}
