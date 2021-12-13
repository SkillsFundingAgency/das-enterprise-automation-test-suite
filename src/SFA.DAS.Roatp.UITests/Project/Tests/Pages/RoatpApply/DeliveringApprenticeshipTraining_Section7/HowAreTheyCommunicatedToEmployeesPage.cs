using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class HowAreTheyCommunicatedToEmployeesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How are these expectations for quality and high standards in apprenticeship training communicated to employees?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");
        
        public HowAreTheyCommunicatedToEmployeesPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EnterHowAreTheyCommunicatedToEmployees()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.HowAreTheyCommunicatedToEmployees);
            return new ApplicationOverviewPage(context);
        }
    }
}