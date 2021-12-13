using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class AssemmentIfThereIsASignificantEventPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will you continue to deliver English and maths training and assessments if there's a significant event?";
        protected override By PageHeader => By.CssSelector(".govuk-label--xl");

        public AssemmentIfThereIsASignificantEventPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EnterTextForSignificantEventAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.SignificantEventText);
            return new ApplicationOverviewPage(_context);
        }
    }
}
