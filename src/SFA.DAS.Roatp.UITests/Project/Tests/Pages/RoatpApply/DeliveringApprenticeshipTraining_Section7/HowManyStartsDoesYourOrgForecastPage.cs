using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class HowManyStartsDoesYourOrgForecastPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How many starts does your organisation forecast ";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");
        private By NumberOfStart => By.CssSelector(".govuk-input");

        public HowManyStartsDoesYourOrgForecastPage(ScenarioContext context) : base(context) => VerifyPage();

        public HowManyEmployeesWillDeliverTrainingPage EnterNumberOfStartsAndContinue()
        {
            formCompletionHelper.EnterText(NumberOfStart, "1234");
            Continue();
            return new HowManyEmployeesWillDeliverTrainingPage(context);
        }
    }
}