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
    public class ShutterPage : AanBasePage
    {
        protected override string PageTitle => "You do not meet the necessary criteria to join the network as an apprentice ambassador";

        public ShutterPage(ScenarioContext context) : base(context) => VerifyPage();

        public void  VerifyApprenticePortalLink()
        {
            formCompletionHelper.ClickLinkByText("Back to the apprenticeship portal");
        }

    }
}

        

