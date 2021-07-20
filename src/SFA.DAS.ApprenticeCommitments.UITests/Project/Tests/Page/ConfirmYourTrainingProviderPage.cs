using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourTrainingProviderPage : ConfirmYourDetailsPage
    {
        protected override string PageTitle => SectionHelper.Section2;

        protected override By ContinueButton => By.CssSelector("#training-provider-confirm");

        public ConfirmYourTrainingProviderPage(ScenarioContext context) : base(context) =>
            VerifyPage(ConfirmingEntityNamePageHeader, objectContext.GetProviderName());
    }
}
