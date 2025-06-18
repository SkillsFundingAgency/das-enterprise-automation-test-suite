using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S5_EvaluatingApprenticeshipTrainingChecks
{
    public class IndividualAccountableForILRDataPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Who is the individual accountable for submitting ILR data for your organisation?";
    }
}