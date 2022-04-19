using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ConfirmApprenticeshipTrainingPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Confirm apprenticeship training";

        protected override By ContinueButton => By.CssSelector("[data-automation='btn-continue']");

        public ConfirmApprenticeshipTrainingPage(ScenarioContext context, Action retryAction) : base(context, false) => VerifyPage(retryAction);

        public EnterTheNameOfTheTrainingProviderPage ConfirmTrainingproviderAndContinue()
        {
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
    }
}
