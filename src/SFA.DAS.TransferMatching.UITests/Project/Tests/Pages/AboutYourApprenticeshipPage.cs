using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class AboutYourApprenticeshipPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Provide more detail about your apprenticeship";

        private By MoreDetailsSelector => By.CssSelector("#more-detail");

        protected override By ContinueButton => By.CssSelector("#opportunity-criteria-continue");

        public AboutYourApprenticeshipPage(ScenarioContext context) : base(context) { }

        public CreateATransfersApplicationPage EnterMoreDetailsAndContinue(string pledgeId)
        {
            formCompletionHelper.EnterText(MoreDetailsSelector, pledgeId ?? tMDataHelper.ApprenticeshipMoreDetails);

            Continue();

            return new CreateATransfersApplicationPage(context);
        }
    }
}