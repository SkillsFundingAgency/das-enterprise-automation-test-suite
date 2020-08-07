using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class ChooseTheTrainingProviderPage : EmployerBasePage
    {
        protected override string PageTitle => "CHOOSE A TRAINING PROVIDER";

        public ChooseTheTrainingProviderPage(ScenarioContext context) : base(context) => VerifyHeadings();

        private void VerifyHeadings() => pageInteractionHelper.VerifyText(Heading1, "FINDING THE RIGHT TRAINING PROVIDER");
    }
}

