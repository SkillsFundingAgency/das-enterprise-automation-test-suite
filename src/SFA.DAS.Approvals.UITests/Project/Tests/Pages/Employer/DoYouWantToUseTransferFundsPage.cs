using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class DoYouWantToUseTransferFundsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Do you want to use transfer funds to pay for this training?";
        private static By CohortFundingOptions => By.CssSelector(".govuk-radios__item");
        protected override By ContinueButton => By.Id("submit-transfer-connection");

        public ChooseYourMainTrainingProviderPage SelectYesIWantToUseTransferFunds()
        {
            string yesOption = "Yes, I will use transfer funds";

            if (formCompletionHelper.GetElementsByText(CohortFundingOptions, yesOption).Count > 1) throw new WebDriverException($"multiple options found with text {yesOption}");

            return GoToAddTrainingProviderDetailsPage(yesOption);
        }

        public ChooseYourMainTrainingProviderPage SelectNoIDontWantToUseTransferFunds() => GoToAddTrainingProviderDetailsPage($"No, I don't want to use transfer funds");

        private ChooseYourMainTrainingProviderPage GoToAddTrainingProviderDetailsPage(string option)
        {
            formCompletionHelper.SelectRadioOptionByText(CohortFundingOptions, option);

            Continue();

            return new ChooseYourMainTrainingProviderPage(context);
        }
    }
}