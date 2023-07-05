using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_MyApplicationsHomePage : FAABasePage
    {
        protected override string PageTitle => "My applications";

        private static By FindAnApprenticeshipLink => By.LinkText("Find an apprenticeship");

        private static By FindTraineeshipLink => By.Id("find-traineeship-link");

        private static By NotificationText => By.ClassName("info-summary");

        private static By DismissNotification => By.LinkText("Dismiss this message");

        private static By ReadFeedbackLink => By.LinkText("Read feedback");

        private static By Settings => By.LinkText("Settings");

        private static By DraftVacancyDeletionInfoText => By.Id("VacancyDeletedInfoMessageText");

        private static By VacancyDeletedLink => By.Id("vacancyDeletedLink");

        private static By SavedVacancy => By.CssSelector($"tr a[href*='{VacancyDetailshref}']");

        private static By DeleteVacancy(string id) => By.CssSelector($"tr a.delete-draft[href*='/apprenticeship/delete/{id}']");

        private static string VacancyDetailshref => "account/apprenticeshipvacancydetails/";

        public FAA_MyApplicationsHomePage(ScenarioContext context) : base(context, false) => VerifyWithoutRefresh();

        public FAA_ApprenticeSearchPage FindAnApprenticeship()
        {
            formCompletionHelper.Click(FindAnApprenticeshipLink);
            return new FAA_ApprenticeSearchPage(context);
        }

        public FAA_TraineeshipSearchPage FindATraineeship()
        {
            formCompletionHelper.Click(FindTraineeshipLink);
            return new FAA_TraineeshipSearchPage(context);
        }

        public FAA_SettingsPage GoToSettings()
        {
            formCompletionHelper.Click(Settings);
            return new FAA_SettingsPage(context);
        }

        private void VerifyVacancySuccessfulNotification()
        {
            pageInteractionHelper.VerifyText(NotificationText, "Your application for " + vacancyTitleDataHelper.VacancyTitle + " has been successful.");
        }

        private void VerifyVacancyUnsuccessfulNotification()
        {
            pageInteractionHelper.VerifyText(NotificationText, "Your application for " + vacancyTitleDataHelper.VacancyTitle + " has been unsuccessful.");
        }

        public void DismissSuccessfulNotification()
        {
            VerifyVacancySuccessfulNotification();
            formCompletionHelper.Click(DismissNotification);
        }

        public FAA_MyApplicationsHomePage DismissUnsuccessfulNotification()
        {
            VerifyVacancyUnsuccessfulNotification();
            formCompletionHelper.Click(DismissNotification);
            return this;
        }

        public FAA_YourFeedbackPage ReadFeedback()
        {
            formCompletionHelper.Click(ReadFeedbackLink);
            return new FAA_YourFeedbackPage(context);
        }

        public FAA_ApprenticeSummaryPage ConfirmVacancyDeletion()
        {
            pageInteractionHelper.WaitforURLToChange("myapplications");
            DeleteDraft();
            pageInteractionHelper.VerifyText(DraftVacancyDeletionInfoText, "You've successfully removed the " + vacancyTitleDataHelper.VacancyTitle + " apprenticeship");
            formCompletionHelper.Click(VacancyDeletedLink);
            return new FAA_ApprenticeSummaryPage(context);
        }

        private void DeleteDraft()
        {
            var element = pageInteractionHelper.GetLinkContains(SavedVacancy, vacancyTitleDataHelper.VacancyTitle);

            var id = element.GetAttribute("href").Replace($"{UrlConfig.FAA_BaseUrl}{VacancyDetailshref}", string.Empty);

            formCompletionHelper.ClickElement(DeleteVacancy(id));
        }
    }
}
