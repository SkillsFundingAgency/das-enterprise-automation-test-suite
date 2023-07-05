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

        public FAA_MyApplicationsHomePage(ScenarioContext context) : base(context, false) => pageInteractionHelper.Verify(() =>
        {
            var result = pageInteractionHelper.CheckText(PageHeader, PageTitle);

            return result.Item1 ? result.Item1 : throw new Exception(ExceptionMessageHelper.GetExceptionMessage("Page", PageTitle, result.Item2));

        }, () => pageInteractionHelper.WaitUntilAnyElements(FindAnApprenticeshipLink));

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
