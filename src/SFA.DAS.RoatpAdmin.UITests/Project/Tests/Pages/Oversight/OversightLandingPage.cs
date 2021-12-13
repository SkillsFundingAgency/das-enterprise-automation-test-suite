using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class OversightLandingPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "RoATP application outcomes";
        protected By ApplicationsTab => By.Id("tab_applications");
        protected By ApplicationsStatus => By.CssSelector("[data-label='Outcome']");
        protected By AppealStatus => By.CssSelector("[data-label='Appeal outcome']");
        protected override By OutcomeTab => By.Id("tab_outcomes");
        protected By AppealOutcomesTab => By.Id("tab_appealsoutcome");
        protected By AppealsTab => By.Id("tab_appeals");
        protected override By OutcomeStatus => By.CssSelector("[data-label='Overall outcome']");
        public OversightLandingPage(ScenarioContext context) : base(context) { }

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

            return new ApplicationSummaryPage(_context);
        }

        public ApplicationSummaryPage SelectApplication_AppealTab()
        {
            formCompletionHelper.ClickElement(AppealsTab);
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ApplicationSummaryPage(_context);
        }

        public ApplicationSummaryPage SelectApplication_AppealOutcomeTab()
        {
            formCompletionHelper.ClickElement(AppealOutcomesTab);
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ApplicationSummaryPage(_context);
        }
    }
}
