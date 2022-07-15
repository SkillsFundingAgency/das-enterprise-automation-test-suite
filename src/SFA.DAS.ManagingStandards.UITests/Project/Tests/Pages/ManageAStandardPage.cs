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
    public class ManageAStandardPage : VerifyBasePage
    {
        protected override string PageTitle => "Standards";

        private By UpdateTheseContactDetailsLink = By.LinkText("/10001259/standards/240/edit-contact-details");

        private By ChangeWhereYouDeliverThisStandardLink = By.LinkText("/10001259/standards/240/edit-location-option");
        
        public ManageAStandardPage(ScenarioContext context) : base(context) => VerifyPage();

        public void ClickUpdateTheseContactDetails()
        {
            formCompletionHelper.Click(UpdateTheseContactDetailsLink);
        }
        public void ClickChangeWhereYouDeliverThisStandard()
        {
            formCompletionHelper.Click(ChangeWhereYouDeliverThisStandardLink);
        }

    }
}
