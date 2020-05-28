using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_MyApplicationsHomePage : FAABasePage
    {
        protected override string PageTitle => "My applications";

        #region Helpers and Context        
        private readonly ScenarioContext _context;
        #endregion

        private By FindAnApprenticeshipLink => By.LinkText("Find an apprenticeship");

        private By FindTraineeshipLink => By.Id("find-traineeship-link");

        private By NotificationText => By.ClassName("info-summary");

        private By DismissNotification => By.LinkText("Dismiss this message");

        private By ReadFeedbackLink => By.LinkText("Read feedback");

        private By Settings => By.LinkText("Settings");

        private By DraftVacancyDeletionInfoText => By.Id("VacancyDeletedInfoMessageText");

        private By VacancyDeletedLink => By.Id("vacancyDeletedLink");

        private By SavedVacancy => By.CssSelector($"tr a[href*='{VacancyDetailshref}']");

        private By DeleteVacancy(string id) => By.CssSelector($"tr a.delete-draft[href*='/apprenticeship/delete/{id}']");

        private string VacancyDetailshref => "account/apprenticeshipvacancydetails/";

        public FAA_MyApplicationsHomePage(ScenarioContext context) : base(context) => _context = context;

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

        public FAA_SettingsPage GoToSettings()
        {
            _formCompletionHelper.Click(Settings);
            return new FAA_SettingsPage(_context);
        }

        private void VerifyVacancySuccessfulNotification()
        {
            _pageInteractionHelper.VerifyText(NotificationText, "Your application for " + _vacancytitledataHelper.VacancyTitle + " has been successful.");
        }

        private void VerifyVacancyUnsuccessfulNotification()
        {
            _pageInteractionHelper.VerifyText(NotificationText, "Your application for " + _vacancytitledataHelper.VacancyTitle + " has been unsuccessful.");
        }

        public void DismissSuccessfulNotification()
        {
            VerifyVacancySuccessfulNotification();
            _formCompletionHelper.Click(DismissNotification);
        }

        public FAA_MyApplicationsHomePage DismissUnsuccessfulNotification()
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

        public FAA_ApprenticeSummaryPage ConfirmVacancyDeletion()
        {
            _pageInteractionHelper.WaitforURLToChange("myapplications");
            DeleteDraft();
            _pageInteractionHelper.VerifyText(DraftVacancyDeletionInfoText, "You've successfully removed the " + _vacancytitledataHelper.VacancyTitle + " apprenticeship");
            _formCompletionHelper.Click(VacancyDeletedLink);
            return new FAA_ApprenticeSummaryPage(_context);
        }

        private void DeleteDraft()
        {
            var element = _pageInteractionHelper.GetLinkContains(SavedVacancy, _vacancytitledataHelper.VacancyTitle);

            var id = element.GetAttribute("href").Replace($"{_config.FAABaseUrl}{VacancyDetailshref}", string.Empty);

            _formCompletionHelper.ClickElement(DeleteVacancy(id));
        }
    }
}
