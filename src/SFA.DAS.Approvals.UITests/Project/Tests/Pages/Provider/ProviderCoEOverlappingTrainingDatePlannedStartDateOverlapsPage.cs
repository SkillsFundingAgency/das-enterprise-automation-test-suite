using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoEOverlappingTrainingDatePlannedStartDateOverlapsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        protected override string PageTitle => "Planned start date overlaps with existing training";

        protected override bool TakeFullScreenShot => false;

        private static By IWillAddLaterRadionButton => By.CssSelector("#overlap-option-3");

        private static By ContactTheEmployerThemselves => By.CssSelector("#overlap-option-2");

        private static By SendStopEmailButton => By.CssSelector("#overlap-option-1");

        public ProviderApproveApprenticeDetailsPage SelectIWillAddApprenticesLater()
        {
            formCompletionHelper.SelectRadioOptionByLocator(IWillAddLaterRadionButton);
            Continue();
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderApproveApprenticeDetailsPage SelectContactTheEmployerThemselves()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ContactTheEmployerThemselves);
            Continue();
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        public ProviderOverlappingTrainingDateEmployerNotifiedPage SendStopEmail()
        {
            formCompletionHelper.SelectRadioOptionByLocator(SendStopEmailButton);
            Continue();
            return new ProviderOverlappingTrainingDateEmployerNotifiedPage(context);
        }
    }
}
