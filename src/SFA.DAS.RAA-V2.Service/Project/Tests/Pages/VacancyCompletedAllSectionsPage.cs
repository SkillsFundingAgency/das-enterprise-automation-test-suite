using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyCompletedAllSectionsPage : PreviewYourAdvertOrVacancyPage
    {
        protected override string PageTitle => "";

        private static By NotificationBanner => By.CssSelector(".govuk-notification-banner__heading");

        protected override By ContinueButton => By.CssSelector(".govuk-button[type='submit']");

        private static By ResubmitVacancyToEmployerButton => By.CssSelector("[data-automation='continue-button']");

        private static By RejectedReason => By.CssSelector("textarea#RejectedReason");

        public VacancyCompletedAllSectionsPage(ScenarioContext context) : base(context) { }

        public AreYouSureYouWantToSubmitPage SubmitAdvert()
        {
            SelectRadioOptionByText("Submit advert to DfE for checking and publication");

            formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");

            return new AreYouSureYouWantToSubmitPage(context);
        }

        public AreYouSureYouWantToRejectPage RejectAdvert()
        {
            SelectRadioOptionByText("Reject advert and return to training provider");

            formCompletionHelper.EnterText(RejectedReason, $"Rejected {vacancyTitleDataHelper.VacancyTitle} by the employer");

            formCompletionHelper.ClickButtonByText(ContinueButton, "Continue");

            return new AreYouSureYouWantToRejectPage(context);
        }

        public VacancyReferencePage ResubmitVacancyToEmployer()
        {
            formCompletionHelper.Click(ResubmitVacancyToEmployerButton);
            return new VacancyReferencePage(context);
        }

        public string GetNotificationBanner() => pageInteractionHelper.GetText(NotificationBanner);
    }
}
