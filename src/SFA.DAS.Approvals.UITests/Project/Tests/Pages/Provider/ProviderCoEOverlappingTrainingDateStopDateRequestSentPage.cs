using OpenQA.Selenium;
using Polly;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoEOverlappingTrainingDateStopDateRequestSentPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        protected override string PageTitle => "Stop date request has been sent";

        private static By IWillAddAnotherApprenticeRadionButton => By.CssSelector("#radio-add-another-apprentice");

        protected override bool TakeFullScreenShot => false;

        public ProviderApproveApprenticeDetailsPage IWillAddAnotherApprentice()
        {
            formCompletionHelper.SelectRadioOptionByLocator(IWillAddAnotherApprenticeRadionButton);
            Continue();

            return new ProviderApproveApprenticeDetailsPage(context);
        }
    }
}
