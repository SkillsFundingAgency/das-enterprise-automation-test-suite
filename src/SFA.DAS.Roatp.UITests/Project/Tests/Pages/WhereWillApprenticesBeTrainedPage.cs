using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class WhereWillApprenticesBeTrainedPage : RoatpBasePage
    {
        protected override string PageTitle => "Where will your apprentices be trained?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By BuildingAndStreetTextBox => By.Id("PAT-660");

        private By TownOrCityTextBox => By.Id("PAT-662");

        private By CountyTextBox => By.Id("PAT-663");

        private By PostcodeTextBox => By.Id("PAT-664");

        public WhereWillApprenticesBeTrainedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTrainingLocationDetailsAndContinue()
        {
            formCompletionHelper.EnterText(BuildingAndStreetTextBox, applydataHelpers.BuildingAndStreet);
            formCompletionHelper.EnterText(TownOrCityTextBox, applydataHelpers.TownOrCity);
            formCompletionHelper.EnterText(CountyTextBox, applydataHelpers.County);
            formCompletionHelper.EnterText(PostcodeTextBox, applydataHelpers.Postcode);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
