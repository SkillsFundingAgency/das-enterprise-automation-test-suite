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
    public class ApplicationSubmittedPage : SignInPage
    {
        protected override string PageTitle => "Application submitted";

        private By NetworkHubLink => By.CssSelector("a[href='/network-hub ']");

        public ApplicationSubmittedPage(ScenarioContext context) : base(context) => VerifyPage();

        public NetworkHubPage ContinueToAmbassadorHub()
        {
            formCompletionHelper.Click(NetworkHubLink);
            return new NetworkHubPage(context);
        }
    }
}