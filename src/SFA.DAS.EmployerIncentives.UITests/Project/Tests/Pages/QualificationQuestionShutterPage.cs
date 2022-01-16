using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class QualificationQuestionShutterPage : EIBasePage
    {
        protected override string PageTitle => $"{ObjectContextExtension.GetOrganisationName(objectContext)} does not have any eligible apprentices";

        public QualificationQuestionShutterPage(ScenarioContext context) : base(context) { }
    }
}
