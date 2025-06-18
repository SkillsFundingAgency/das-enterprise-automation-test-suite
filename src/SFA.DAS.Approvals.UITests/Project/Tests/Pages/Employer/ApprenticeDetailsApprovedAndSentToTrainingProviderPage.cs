using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsApprovedAndSentToTrainingProviderPage(ScenarioContext context) : CohortReferenceBasePage(context)
    {
        protected override string PageTitle => "Apprentice details approved and sent to training provider";

        protected override bool TakeFullScreenShot => false;

        protected override By PageHeader => PanelTitle;
    }
}