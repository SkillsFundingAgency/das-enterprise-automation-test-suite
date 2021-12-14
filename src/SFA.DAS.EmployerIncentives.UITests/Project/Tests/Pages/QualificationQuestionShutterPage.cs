using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class QualificationQuestionShutterPage : EIBasePage
    {
        protected override string PageTitle => $"{ObjectContextExtension.GetOrganisationName(objectContext)} does not have any eligible apprentices";

        public QualificationQuestionShutterPage(ScenarioContext context) : base(context)  { }

        public HomePage ClickOnReturnToAccountHomeLink()
        {
            formCompletionHelper.Click(ReturnToAccountHomeCTA);
            return new HomePage(context);
        }
    }
}
