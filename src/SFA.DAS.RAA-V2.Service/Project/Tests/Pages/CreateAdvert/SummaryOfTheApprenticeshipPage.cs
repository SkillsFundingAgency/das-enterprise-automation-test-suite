using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class SummaryOfTheApprenticeshipPage : Raav2BasePage
    {
        protected override string PageTitle => IsTraineeship ? "Summary of the traineeship" : "Summary of the apprenticeship";

        private static By ShortDescSelector => By.CssSelector("textarea#ShortDescription");

        protected override By ContinueButton => By.CssSelector(".govuk-button.save-button");

        public SummaryOfTheApprenticeshipPage(ScenarioContext context) : base(context) { }

        public DescriptionPage EnterShortDescription()
        {
            formCompletionHelper.EnterText(ShortDescSelector, RAA.DataGenerator.RAAV2DataHelper.RandomAlphabeticString(60));
            Continue();
            return new DescriptionPage(context);
        }

    }
}
