using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourApprenticeshipDetailsPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => SectionHelper.Section3;
        protected override By ContinueButton => By.CssSelector("#apprenticeship-details-confirm");

        public ConfirmYourApprenticeshipDetailsPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
