using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_EnterBasicVacancyDetailsPage : RAA_BasicVacancyDetailsPage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly RAAV1ManagedataHelper _managedataHelper;
        #endregion

        private By TitleComments => By.CssSelector("summary[aria-controls='details-content-0']");

        private By TitleCommentTextArea => By.CssSelector("#TitleComment");

        public Manage_EnterBasicVacancyDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _managedataHelper = context.Get<RAAV1ManagedataHelper>();
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
            formCompletionHelper.Click(TitleComments);
            pageInteractionHelper.WaitForElementToChange(TitleComments, AttributeHelper.AriaExpanded, "true");
            formCompletionHelper.EnterText(TitleCommentTextArea, _managedataHelper.TitleComments);
            formCompletionHelper.ClickButtonByText("Save");
        }
    }
}
