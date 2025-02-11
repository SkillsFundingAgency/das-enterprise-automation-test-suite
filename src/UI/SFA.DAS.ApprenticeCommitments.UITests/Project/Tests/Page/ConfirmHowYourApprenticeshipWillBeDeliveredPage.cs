using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmHowYourApprenticeshipWillBeDeliveredPage : ConfirmYourDetailsBasePage
    {
        protected override string PageTitle => OverviewPageHelper.Section4;
        protected override By ContinueButton => By.CssSelector("#apprentice-delivered-confirm");

        public ConfirmHowYourApprenticeshipWillBeDeliveredPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
