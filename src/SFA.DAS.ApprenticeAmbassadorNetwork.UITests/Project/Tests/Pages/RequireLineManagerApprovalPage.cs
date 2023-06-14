using System;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class RequiresLineManagerApprovalPage : AanBasePage
    {
        protected override string PageTitle => "Do you have approval from your line manager to join the network?";

        public RequiresLineManagerApprovalPage(ScenarioContext context) : base(context) => VerifyPage();

        public SearchEmployerNamePage YesHaveApprovalFromMaanagerAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
            return new SearchEmployerNamePage(context);
        }
        public ShutterPage NoHaveApprovalFromMaanagerAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("No");
            Continue();
            return new ShutterPage(context);
        }
    }    
}
        

