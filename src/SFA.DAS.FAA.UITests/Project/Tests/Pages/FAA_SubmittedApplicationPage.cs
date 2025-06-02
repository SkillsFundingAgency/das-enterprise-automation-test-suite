using NUnit.Framework;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_SubmittedApplicationPage(ScenarioContext context) : FAA_ApplicationsPage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-m");

        protected override string PageTitle => "Submitted";

        private By ApplicationWithdrawnBanner => By.CssSelector(".govuk-notification-banner__content");

        private By GetWithdrawApplicationLink(string vacancyRef) => By.Id($"VAC{vacancyRef}-withdraw");

        private By GetWithdrawnVacancyTitleLocator(string vacancyRef) => By.CssSelector($"a[href*='/apprenticeship/VAC{vacancyRef}?source=applications&tab=Submitted']");

        private By FirstWithdrawLink => By.CssSelector("[id^='VAC'][id$='-withdraw']");
        public FAA_SubmittedApplicationPage WithdrawSelectedApplication()
        {
            var vacancyRef = objectContext.GetVacancyReference();
            var vacancyTitle = GetWithdrawnVacancyTitle(vacancyRef);

            objectContext.Set("vacancytitle", vacancyTitle);

            ClickToWithdrawApplication(vacancyRef);
            PerformVacancyWithdrawalActions();
            AssertApplicationWithdrawnMessage(vacancyTitle);

            return new FAA_SubmittedApplicationPage(context);
        }
        public FAA_SubmittedApplicationPage WithdrawRandomlySelectedApplication()
        {
            ClickIfDisplayed(FirstWithdrawLink);
            PerformVacancyWithdrawalActions();

            return new FAA_SubmittedApplicationPage(context);
        }

        private string GetWithdrawnVacancyTitle(string vacancyRef)
        {
            var vacancyTitleLocator = GetWithdrawnVacancyTitleLocator(vacancyRef);
            return pageInteractionHelper.GetText(vacancyTitleLocator);
        }

        private void ClickToWithdrawApplication(string vacancyRef)
        {
            var withdrawApplicationLink = GetWithdrawApplicationLink(vacancyRef);
            formCompletionHelper.Click(withdrawApplicationLink);
        }

        private void PerformVacancyWithdrawalActions()
        {
            SelectRadioOptionByForAttribute("WithdrawApplication");
            Continue();
        }

        private void AssertApplicationWithdrawnMessage(string vacancyTitle)
        {
            var organisationName = objectContext.GetEmployerName();
            var expectedMessage = $"Application withdrawn for {vacancyTitle} at {organisationName}.";
            var actualMessage = pageInteractionHelper.GetText(ApplicationWithdrawnBanner);

            Assert.AreEqual(expectedMessage, actualMessage, "The application withdrawn banner message does not match the expected value.");
        }
    }
}
