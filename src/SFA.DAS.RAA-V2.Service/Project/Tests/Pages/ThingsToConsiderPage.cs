using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ThingsToConsiderPage : RAAV2CSSBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-label--xl");

        protected override string PageTitle => "What else would you like the applicant to consider? (optional)";

        private By ThingsToConsider => By.CssSelector("#ThingsToConsider");

        public ThingsToConsiderPage(ScenarioContext context) : base(context) { }

        public VacancyPreviewPart2Page EnterThingsToConsider()
        {
            formCompletionHelper.EnterText(ThingsToConsider, rAAV2DataHelper.OptionalMessage);
            Continue();
            return new VacancyPreviewPart2Page(context);
        }

        public CreateAnApprenticeshipAdvertPage EnterThingsToConsiderAndReturnToCreateAdvert()
        {
            formCompletionHelper.EnterText(ThingsToConsider, rAAV2DataHelper.OptionalMessage);
            Continue();
            return new CreateAnApprenticeshipAdvertPage(context);
        }
    }
}
