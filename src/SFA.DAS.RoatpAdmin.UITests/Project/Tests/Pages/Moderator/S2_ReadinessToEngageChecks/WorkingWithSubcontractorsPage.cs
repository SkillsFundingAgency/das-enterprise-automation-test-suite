using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class WorkingWithSubcontractorsPage : ModeratorBasePage
    {
        protected override string PageTitle => "Using subcontractors in the first 12 months of joining the APAR";

        public WorkingWithSubcontractorsPage(ScenarioContext context) : base(context) { }

        public DueDiligenceOnSubcontractorsPage SelectPassAndContinueInWorkingWithSubcontractorsPage() => SelectActionAndContinue(() => SelectPassAndContinueToSubSection());

        public DueDiligenceOnSubcontractorsPage SelectFailAndContinueInWorkingWithSubcontractorsPage() => SelectActionAndContinue(() => SelectFailAndContinueToSubSection());

        public DueDiligenceOnSubcontractorsPage SelectContinueInWorkingWithSubcontractorsPage() => SelectActionAndContinue(() => Continue());

        private DueDiligenceOnSubcontractorsPage SelectActionAndContinue(Action action)
        {
            action.Invoke();
            return new DueDiligenceOnSubcontractorsPage(context);
        }
    }
}