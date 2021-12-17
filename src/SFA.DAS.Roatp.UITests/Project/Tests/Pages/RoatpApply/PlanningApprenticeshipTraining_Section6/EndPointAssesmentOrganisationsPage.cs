using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class EndPointAssesmentOrganisationsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation engage with end-point assessment organisations (EPAOs)?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public EndPointAssesmentOrganisationsPage(ScenarioContext context) : base(context) => VerifyPage();

        public TransitionFromFrameworksToStandardPage EnterTextRegardingEngageWithEPAOandContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.EngageWithEPAO);
            return new TransitionFromFrameworksToStandardPage(context);
        }
        public AwardingBodiesPage EnterTextRegardingEngageWithEPAOandContinue_FrameworksOnly()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.EngageWithEPAO);
            return new AwardingBodiesPage(context);
        }
        public ApplicationOverviewPage EnterTextRegardingEngageWithEPAOandContinue_Main_Employer_NewProviders()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.EngageWithEPAO);
            return new ApplicationOverviewPage(context);
        }
    }
}
