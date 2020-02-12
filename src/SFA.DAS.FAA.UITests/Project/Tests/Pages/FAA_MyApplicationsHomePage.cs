using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_MyApplicationsHomePage : BasePage
    {
        protected override string PageTitle => "My applications";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _PageIntercationHelper;
        private readonly ScenarioContext _context;
        private readonly VacancyTitleDatahelper _dataHelper;
        #endregion
        
        private By FindAnApprenticeshipLink => By.Id("find-apprenticeship-link");

        private By FindTraineeshipLink => By.Id("find-traineeship-link");

        private By SignOutCss => By.XPath("//a[contains(.,'Sign out')]");

        private By NotificationText => By.ClassName("info-summary");

        private By DismissNotification => By.LinkText("Dismiss this message");

        private By ReadFeedbackLink => By.LinkText("Read feedback");

        public FAA_MyApplicationsHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _PageIntercationHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<VacancyTitleDatahelper>();
            VerifyPage();
        }

        public FAA_ApprenticeSearchPage FindAnApprenticeship()
        {
            _formCompletionHelper.Click(FindAnApprenticeshipLink);
            return new FAA_ApprenticeSearchPage(_context);
        }

        public FAA_TraineeshipSearchPage FindATraineeship()
        {
            _formCompletionHelper.Click(FindTraineeshipLink);
            return new FAA_TraineeshipSearchPage(_context);
        }

        public void ClickSignOut()
        {
            _formCompletionHelper.Click(SignOutCss);
        }
        private void VerifyVacancySuccessfulNotification()
        {
            _PageIntercationHelper.VerifyText(NotificationText, "Your application for "+_dataHelper.VacancyTitle+" has been successful."); 
        }

        private void VerifyVacancyUnsuccessfulNotification()
        {
            _PageIntercationHelper.VerifyText(NotificationText, "Your application for "+_dataHelper.VacancyTitle+" has been unsuccessful.");
        }

        public void DismissSuccessfulNotification()
        {
            VerifyVacancySuccessfulNotification();
            _formCompletionHelper.Click(DismissNotification);
        }

        public  FAA_MyApplicationsHomePage DismissUnsuccessfulNotification()
        {
            VerifyVacancyUnsuccessfulNotification();
            _formCompletionHelper.Click(DismissNotification);
            return this;
        }

        public FAA_YourFeedbackPage ReadFeedback()
        {
            _formCompletionHelper.Click(ReadFeedbackLink);
            return new FAA_YourFeedbackPage(_context);
        }
    }
}
