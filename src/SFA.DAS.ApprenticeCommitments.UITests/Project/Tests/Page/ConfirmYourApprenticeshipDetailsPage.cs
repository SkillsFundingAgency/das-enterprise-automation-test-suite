using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourApprenticeshipDetailsPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => "Your Apprenticeship Details";

        protected override By ContinueButton => By.CssSelector("#apprenticeship-details-confirm");

        public ConfirmYourApprenticeshipDetailsPage(ScenarioContext context) : base(context) { }
    }
}
