using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class WhyDoYouWantToStopThisApprenticeshipPage : ApprovalsBasePage        
    {
        protected override string PageTitle => "Why do you want to stop this apprenticeship?";
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Save and continue')]");

        public WhyDoYouWantToStopThisApprenticeshipPage(ScenarioContext context) : base(context) { }

        public ThisApprenticeshipTrainingStopPage SelectedReasonToStop(string reason)
        {
            formCompletionHelper.SelectRadioOptionByText(RadioLabels, reason);
            Continue();
            return new ThisApprenticeshipTrainingStopPage(context);
        }


    }
}
