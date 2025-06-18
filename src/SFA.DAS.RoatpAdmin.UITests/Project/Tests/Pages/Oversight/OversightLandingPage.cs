using OpenQA.Selenium;
using SFA.DAS.RoatpAdmin.Service.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class OversightLandingPage(ScenarioContext context) : RoatpNewAdminBasePage(context)
    {
        protected override string PageTitle => "RoATP application outcomes";
        protected static By ApplicationsTab => By.Id("tab_applications");
        protected static By ApplicationsStatus => By.CssSelector("[data-label='Outcome']");
        protected static By AppealStatus => By.CssSelector("[data-label='Appeal outcome']");
        protected override By OutcomeTab => By.Id("tab_outcomes");
        protected static By AppealOutcomesTab => By.Id("tab_appealsoutcome");
        protected static By AppealsTab => By.Id("tab_appeals");
        protected override By OutcomeStatus => By.CssSelector("[data-label='Overall outcome']");

        public OversightLandingPage VerifyApplicationsOutcomeStatus(string expectedStatus)
        {
            VerifyOutcomeStatus(ApplicationsTab, ApplicationsStatus, expectedStatus);
            return this;
        }
        public OversightLandingPage VerifyApplicationsAppealOutcomeStatus(string expectedStatus)
        {
            VerifyOutcomeStatus(AppealOutcomesTab, AppealStatus, expectedStatus);
            return this;
        }

        public OversightLandingPage VerifyOverallOutcomeStatus(string expectedStatus)
        {
            VerifyOutcomeStatus(expectedStatus);
            return this;
        }

        public ApplicationSummaryPage SelectApplication(string expectedStatus)
        {
            if (expectedStatus == "IN PROGRESS" || expectedStatus == "UNSUCCESSFUL") VerifyOverallOutcomeStatus(expectedStatus);
            else VerifyApplicationsOutcomeStatus(expectedStatus);

            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());

            return new ApplicationSummaryPage(context);
        }

        public ApplicationSummaryPage SelectApplication_AppealTab()
        {
            formCompletionHelper.ClickElement(AppealsTab);
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ApplicationSummaryPage(context);
        }

        public ApplicationSummaryPage SelectApplication_AppealOutcomeTab()
        {
            formCompletionHelper.ClickElement(AppealOutcomesTab);
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ApplicationSummaryPage(context);
        }
    }
}
