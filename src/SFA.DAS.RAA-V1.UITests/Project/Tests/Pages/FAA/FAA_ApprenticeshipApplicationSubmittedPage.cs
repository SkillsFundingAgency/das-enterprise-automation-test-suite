using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_ApprenticeshipApplicationSubmittedPage : FAA_ApplicationSubmittedPage
    {
        protected override string PageTitle => "Apprenticeship application submitted";

        public FAA_ApprenticeshipApplicationSubmittedPage(ScenarioContext context) : base(context) { }
    }

}
