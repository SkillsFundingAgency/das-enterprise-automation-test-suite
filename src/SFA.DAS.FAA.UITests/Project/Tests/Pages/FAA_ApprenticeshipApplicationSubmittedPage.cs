using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeshipApplicationSubmittedPage : FAA_ApplicationSubmittedPage
    {
        protected override string PageTitle => "Apprenticeship application submitted";

        public FAA_ApprenticeshipApplicationSubmittedPage(ScenarioContext context) : base(context) { }
    }

}
