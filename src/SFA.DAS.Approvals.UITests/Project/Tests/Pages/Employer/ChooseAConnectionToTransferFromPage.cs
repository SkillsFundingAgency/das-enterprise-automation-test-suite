using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ChooseAConnectionToTransferFromPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Choose a connection";
        protected override By ContinueButton => By.Id("submit-transfer-connection");
        private static By TransferConnectionRadioOption => By.ClassName("govuk-radios__label");

        public ChooseYourMainTrainingProviderPage SelectTransferSenderAndContinue()
        {
            formCompletionHelper.Click(TransferConnectionRadioOption);
            Continue();
            return new ChooseYourMainTrainingProviderPage(context);
        }

    }


}
