using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AddYourBusinessDetailsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Add your business details";

        private static By AdditionalLocationSelector => By.CssSelector("#AdditionalLocation");

        private static By AdditionalLocationTextSelector => By.CssSelector("#AdditionalLocationText");

        private static By SpecificLocationSelector => By.CssSelector("#SpecificLocation");

        protected override By ContinueButton => By.CssSelector("#opportunity-criteria-continue");

        public AddYourBusinessDetailsPage(ScenarioContext context) : base(context) { }

        public CreateATransfersApplicationPage EnterBusinessDetailsAndContinue()
        {
            SelectRandomCheckbox();

            var location = Helpers.TMDataHelper.GetRandomLocation();

            if (pageInteractionHelper.IsElementPresent(AdditionalLocationSelector))
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(AdditionalLocationSelector));

                formCompletionHelper.EnterText(AdditionalLocationTextSelector, location);
            }
            else
            {
                formCompletionHelper.EnterText(SpecificLocationSelector, location);
            }

            Continue();

            return new CreateATransfersApplicationPage(context);
        }
    }
}