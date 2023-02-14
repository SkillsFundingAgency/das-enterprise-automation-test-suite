using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApprenticeshipDeliveryModelPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm the apprenticeship delivery model";

        private By ContinueBtn => By.XPath("//*[@id='selectDeliveryModel']/button");

        public ConfirmApprenticeshipDeliveryModelPage(ScenarioContext context) : base(context) { }

        public EditApprenticeDetailsPage ConfirmDeliveryModelChangeToRegular()
        {
            formCompletionHelper.ClickElement(ContinueBtn);
            return new EditApprenticeDetailsPage(context);
        }
    }
}
