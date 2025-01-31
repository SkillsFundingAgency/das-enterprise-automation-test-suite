using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SelectAConnectionToTransferFromPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Select a connection";
        protected override By ContinueButton => By.Id("submit-transfer-connection");
        private static By TransferConnectionRadioOption => By.ClassName("govuk-radios__label");

        public AddTrainingProviderDetailsPage SelectTransferSenderAndContinue()
        {
            formCompletionHelper.Click(TransferConnectionRadioOption);
            Continue();
            return new AddTrainingProviderDetailsPage(context);
        }

    }


}
