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
    public class RequiresLineManagerApprovalPage : TermsAndConditionsPage
    {
        protected override string PageTitle => pageTitle;

        private readonly string pageTitle;

        private static By YesRadio => By.id("yes");

        public RequiresLineManagerApprovalPage(ScenarioContext context, string requireslinemanagersapproval) : base(context, false)
        {
            pageTitle = requireslinemanagersapproval;

            VerifyPage();
        }

        public YourContactInformationForThisStandardPage YesStandardIsCorrectAndContinue()
        {
        formCompletionHelper.SelectRadioOptionByLocator(YesRadio);
        Continue();
        return new SearchEmployerNamePage(context);
        }
        
}
        

