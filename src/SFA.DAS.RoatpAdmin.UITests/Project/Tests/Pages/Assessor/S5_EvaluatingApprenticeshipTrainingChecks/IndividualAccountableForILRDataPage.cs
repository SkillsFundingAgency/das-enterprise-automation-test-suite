using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S5_EvaluatingApprenticeshipTrainingChecks
{ 
    public class IndividualAccountableForILRDataPage : AssessorBasePage
{
        protected override string PageTitle => "Who is the individual accountable for submitting ILR data for your organisation?";

        public IndividualAccountableForILRDataPage(ScenarioContext context) : base(context) { }
    }
}