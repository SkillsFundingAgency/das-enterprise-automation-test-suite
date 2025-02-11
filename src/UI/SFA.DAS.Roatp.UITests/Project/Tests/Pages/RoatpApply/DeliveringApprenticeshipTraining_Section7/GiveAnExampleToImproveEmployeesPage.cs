using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class GiveAnExampleToImproveEmployeesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Give an example of how your organisation used this policy to improve employee sector expertise";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public GiveAnExampleToImproveEmployeesPage(ScenarioContext context) : base(context) => VerifyPage();

        public GiveAnExampleToMaintainEmployeesPage EnterAnExampleToImproveEmployees()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.ExampleToImproveEmployees);
            return new GiveAnExampleToMaintainEmployeesPage(context);
        }
    }
}