using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class WhereWillApprenticesBeTrainedPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Where will your apprentices be trained?";

        private By BuildingAndStreetTextBox => By.Id("PAT-670");

        private By TownOrCityTextBox => By.Id("PAT-671");

        private By CountyTextBox => By.Id("PAT-672");

        private By PostcodeTextBox => By.Id("PAT-673");

        public WhereWillApprenticesBeTrainedPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EnterTrainingLocationDetailsAndContinue()
        {
            formCompletionHelper.EnterText(BuildingAndStreetTextBox, applydataHelpers.BuildingAndStreet);
            formCompletionHelper.EnterText(TownOrCityTextBox, applydataHelpers.TownOrCity);
            formCompletionHelper.EnterText(CountyTextBox, applydataHelpers.County);
            formCompletionHelper.EnterText(PostcodeTextBox, applydataHelpers.Postcode);
            Continue();
            return new ApplicationOverviewPage(context);
        }
    }
}
