using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages
{
    public class RegulatedStandardPage : VerifyBasePage
    {
        protected override string PageTitle => "This is a regulated standard";

        private By ApprovesYesRadio = By.Id("IsApprovedByRegulator");
        private By ApprovesNoRadio = By.Id("IsApprovedByRegulator-No");
        public RegulatedStandardPage(ScenarioContext context) : base(context) => VerifyPage();
        
        public ManageTheStandardsYouDeliverPage ApproveStandard_FromStandardsPage()
        {
                formCompletionHelper.SelectCheckbox(ApprovesYesRadio);
                Continue();
                return new ManageTheStandardsYouDeliverPage(context);
        }

        public YouMustBeApprovePage DisApproveStandard()
        {
            formCompletionHelper.SelectCheckbox(ApprovesNoRadio);
            Continue();
            return new YouMustBeApprovePage(context);
        }
    }
}
