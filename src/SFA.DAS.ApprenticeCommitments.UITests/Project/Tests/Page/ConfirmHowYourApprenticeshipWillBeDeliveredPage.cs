using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmHowYourApprenticeshipWillBeDeliveredPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "How your apprenticeship will be delivered";
        protected override By ContinueButton => By.CssSelector("#apprentice-delivered-confirm");

        public ConfirmHowYourApprenticeshipWillBeDeliveredPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
