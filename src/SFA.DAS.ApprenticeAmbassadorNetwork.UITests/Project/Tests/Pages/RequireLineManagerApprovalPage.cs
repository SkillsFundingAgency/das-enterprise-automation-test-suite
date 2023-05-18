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
        protected override string PageTitle => "This is a regulated standard";

        private static By YesRadio => By.Id("yes");

        public RequiresLineManagerApprovalPage(ScenarioContext context) : base(context) => VerifyPage();

        public SearchEmployerNamePage YesHaveApprovalFromMaanagerAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(YesRadio);
            Continue();
            return new SearchEmployerNamePage(context);
        }
    }    
}
        

