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
    public class ManageTheStandardsYouDeliverPage : VerifyBasePage
    {
        protected override string PageTitle => "ManageTheStandardsYouDeliverPage";

        private By AdvancedCarpentryAndJoineryLevel3Link = By.LinkText("/10001259/standards/240");

        private By BricklayerLevel2Link = By.LinkText("/10001259/standards/287");

        public ManageTheStandardsYouDeliverPage(ScenarioContext context) : base(context) => VerifyPage();

        public void ClickAdvancedCarpentryAndJoineryLevel3()
        {
            formCompletionHelper.Click(AdvancedCarpentryAndJoineryLevel3Link);
        }

        public void ClickBrickLayerLevel2()
        {
            formCompletionHelper.Click(BricklayerLevel2Link);
        }
    }
}
