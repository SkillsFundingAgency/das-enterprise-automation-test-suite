using OpenQA.Selenium;
using SFA.DAS.EsfaAdmin.Service.Project;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Clarification;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
    public class RoatpAssessorApplicationsHomePage : AssessorBasePage
    {
        protected override string PageTitle => "RoATP assessor applications";

        private By Assessor1Link => By.CssSelector("a[href*='assessorNumber=1']");
        private By Assessor2Link => By.CssSelector("a[href*='assessorNumber=2']");

        public RoatpAssessorApplicationsHomePage(ScenarioContext context) : base(context) { }

        public ApplicationAssessmentOverviewPage Assessor1SelectsAssignToMe() => AssessorSelectsAssignToMe(Assessor1Link);

        public ApplicationAssessmentOverviewPage Assessor2SelectsAssignToMe() => AssessorSelectsAssignToMe(Assessor2Link);

        public ModerationApplicationAssessmentOverviewPage ModeratorSelectsAssignToMe()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ModerationTab));
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ModerationApplicationAssessmentOverviewPage(context);
        }

        public ClarificationApplicationAssessmentOverviewPage ClarificationSelectsAssignToMe()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ClarificationTab));
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ClarificationApplicationAssessmentOverviewPage(context);
        }

        public ModerationApplicationAssessmentOverviewPage SelectFromOutcomeTab()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(OutcomeTab));
            formCompletionHelper.ClickLinkByText(objectContext.GetProviderName());
            return new ModerationApplicationAssessmentOverviewPage(context);
        }
        public IWebElement GetApplication() => GetApplication(Assessor1Link);

        private ApplicationAssessmentOverviewPage AssessorSelectsAssignToMe(By columnIdentifier)
        {
            formCompletionHelper.ClickElement(() => GetApplication(columnIdentifier));
            return new ApplicationAssessmentOverviewPage(context);
        }

        private  IWebElement GetApplication(By columnIdentifier)
        {
            return tableRowHelper.GetColumn(objectContext.GetUkprn(), columnIdentifier);
        }

        public new RoatpAssessorApplicationsHomePage VerifyOutcomeStatus(string expectedStatus)
        {
            base.VerifyOutcomeStatus(expectedStatus);
            return new RoatpAssessorApplicationsHomePage(context);
        }

        public RoatpAssessorApplicationsHomePage VerifyClarificationStatus()
        {
            VerifyClarificationStatus(UkprnStatus, objectContext.GetUkprn());
            return new RoatpAssessorApplicationsHomePage(context);
        }

        public RoatpAssessorApplicationsHomePage ClearSearchResult_AssessorOutcomeTab()
        {
            formCompletionHelper.ClickElement(OutcomeTab);
            return this;
        }

        public RoatpAssessorApplicationsHomePage ConfirmAssessorSearchByUkprn()
        {
            SearchProviderByUKPRN();
            return this;
        }

        public RoatpAssessorApplicationsHomePage SelectInOutcomeTab_Assessor()
        {
            formCompletionHelper.ClickElement(OutcomeTab);
            return this;
        }

        public RoatpAssessorApplicationsHomePage ConfirmAssessorSearchByName()
        {
            SearchProviderByName();
            return this;
        }
    }
}
