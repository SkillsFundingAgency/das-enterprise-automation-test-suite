using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AddYourBusinessDetailsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Add your business details";

        private readonly ScenarioContext _context;

        private By AdditionalLocationSelector => By.CssSelector("#AdditionalLocation");

        private By AdditionalLocationTextSelector => By.CssSelector("#AdditionalLocationText");

        private By SpecificLocationSelector => By.CssSelector("#SpecificLocation");

        protected override By ContinueButton => By.CssSelector("#opportunity-criteria-continue");

        public AddYourBusinessDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public CreateATransfersApplicationPage EnterBusinessDetailsAndContinue()
        {
            SelectRandomCheckbox();

            var location = tMDataHelper.GetRandomLocation();

            if (pageInteractionHelper.IsElementDisplayed(AdditionalLocationSelector))
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(AdditionalLocationSelector));

                formCompletionHelper.EnterText(AdditionalLocationTextSelector, location);
            }
            else
            {
                formCompletionHelper.EnterText(SpecificLocationSelector, location);
            }

            Continue();

            return new CreateATransfersApplicationPage(_context);
        }
    }
}