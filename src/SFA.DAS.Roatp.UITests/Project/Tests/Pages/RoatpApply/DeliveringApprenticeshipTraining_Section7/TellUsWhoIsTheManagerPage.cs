using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.DeliveringApprenticeshipTraining_Section7
{
    public class TellUsWhoIsTheManagerPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Tell us who's the overall manager for this team";

        private static By FullName => By.CssSelector(".govuk-input[type='text']");

        public TellUsWhoIsTheManagerPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EnterDetailsOfTheManager()
        {
            formCompletionHelper.EnterText(FullName, RoatpApplyDataHelpers.FullName);
            SelectRadioOptionByText("Over 18 months");
            Continue();
            return new ApplicationOverviewPage(context);
        }

        public ApplicationOverviewPage EnterDetailsOfTheManagerPerson()
        {
            formCompletionHelper.EnterText(FullName, RoatpApplyDataHelpers.FullName);
            SelectYesAndContinue();
            return new ApplicationOverviewPage(context);
        }
    }
}