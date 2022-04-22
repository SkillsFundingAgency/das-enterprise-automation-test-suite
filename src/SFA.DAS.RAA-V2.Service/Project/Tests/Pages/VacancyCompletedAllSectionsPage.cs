using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyCompletedAllSectionsPage : PreviewYouAdvertOrVacancyPage
    {
        protected override string PageTitle => "You have completed all required sections";

        protected override By PageHeader => By.CssSelector(".info-summary__header-bar");

        private By NotificationBanner => By.CssSelector(".govuk-notification-banner__heading");

        protected override By ContinueButton => By.CssSelector(".govuk-button[type='submit']");

        private By ResubmitVacancyToEmployerButton => By.CssSelector(".govuk-button[type='submit'][value='Resubmit vacancy to employer']");

        private By RejectedReason => By.CssSelector("textarea#RejectedReason");

        public VacancyCompletedAllSectionsPage(ScenarioContext context) : base(context) { }
     
        public AreYouSureYouWantToSubmitPage SubmitAdvert()
        {
            SelectRadioOptionByText("Submit advert to ESFA for checking and publication");

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
