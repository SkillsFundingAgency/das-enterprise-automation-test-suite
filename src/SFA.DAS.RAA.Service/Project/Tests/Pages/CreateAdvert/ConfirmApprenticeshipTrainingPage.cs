using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class ConfirmApprenticeshipTrainingPage : RaaBasePage
    {
        protected override string PageTitle => "Confirm apprenticeship training";

        protected override By ContinueButton => By.CssSelector("[data-automation='btn-continue']");
        private static By FoundationCardBlockElement => By.CssSelector(".govuk-caption-m");
        private static String ExpectedFoundationApprenticeshipText => "Foundation apprenticeship";

        public ConfirmApprenticeshipTrainingPage(ScenarioContext context, Action retryAction) : base(context, false) => VerifyPage(retryAction);

        public EnterTheNameOfTheTrainingProviderPage ConfirmTrainingproviderAndContinue(bool isFoundationAdvert)
        {
            if (isFoundationAdvert)
            {
                CheckFoundationTag();
                CheckFoundationCardText();
            }
            Continue();
            return new EnterTheNameOfTheTrainingProviderPage(context);
        }

        public ChooseTrainingProviderPage ConfirmTrainingAndContinue()
        {
            Continue();
            return new ChooseTrainingProviderPage(context);
        }

        public SubmitNoOfPositionsPage ConfirmAndNavigateToNoOfPositionsPage()
        {
            Continue();
            return new SubmitNoOfPositionsPage(context);
        }

        public SummaryOfTheApprenticeshipPage ConfirmTrainingAndContinueToSummaryPage()
        {
            Continue();
            return new SummaryOfTheApprenticeshipPage(context);
        }

        private void CheckFoundationCardText()
        {
            var actualFoundationCardText = pageInteractionHelper.GetText(FoundationCardBlockElement).Trim();
            pageInteractionHelper.VerifyText(actualFoundationCardText, ExpectedFoundationApprenticeshipText);
        }
    }
}
