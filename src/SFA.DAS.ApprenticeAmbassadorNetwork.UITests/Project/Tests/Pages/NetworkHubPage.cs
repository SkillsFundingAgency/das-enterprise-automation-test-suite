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
    public class NetworkHubPage : SignInPage
    {
        protected override string PageTitle => "Your network hub";

        public NetworkHubPage(ScenarioContext context) : base(context) => VerifyPage();

    }
}