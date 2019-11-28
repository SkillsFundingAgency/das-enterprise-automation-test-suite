using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_EnterBasicVacancyDetailsPage : RAA_BasicVacancyDetailsPage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ManagedataHelper _managedataHelper;
        #endregion

        private By TitleComments => By.CssSelector("summary[aria-controls='details-content-0']");

        private By TitleCommentTextArea => By.CssSelector("#TitleComment");

        public Manage_EnterBasicVacancyDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _managedataHelper = context.Get<ManagedataHelper>();
        }

        public Manage_VacanacyPreviewPage AddApprenticeshipTitleComments()
        {
            AddTitleComments();
            return new Manage_VacanacyPreviewPage(_context);
        }

        public Manage_OpportunityPreviewPage AddTraineeshipTitleComments()
        {
            AddTitleComments();
            return new Manage_OpportunityPreviewPage(_context);
        }

        private void AddTitleComments()
        {
            _formCompletionHelper.Click(TitleComments);
            _pageInteractionHelper.WaitForElementToChange(TitleComments, AttributeHelper.AriaExpanded, "true");
            _formCompletionHelper.EnterText(TitleCommentTextArea, _managedataHelper.TitleComments);
            _formCompletionHelper.ClickButtonByText("Save");
        }
    }
}
