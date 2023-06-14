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
    public class AccessDeniedPage : AanBasePage
    {
        protected override string PageTitle => "You do not have access to this area of the website";

        public AccessDeniedPage(ScenarioContext context) : base(context) => VerifyPage();

        public void  VerifyHomeLink()
        {
            formCompletionHelper.ClickLinkByText("Home");
        }

    }
}

        

