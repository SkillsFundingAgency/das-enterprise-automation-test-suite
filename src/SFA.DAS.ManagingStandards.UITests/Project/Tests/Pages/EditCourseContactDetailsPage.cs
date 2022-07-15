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
    public class YourContactInformationForThisStandardPage : VerifyBasePage
    {
        protected override string PageTitle => "Edit course contact details";

        private By EmailAddressTextBox => By.Id("ContactUsEmail");
        private By TelephoneNumberTextBox => By.Id("ContactUsPhoneNumber");
        private By ContactPageTextBox => By.Id("ContactUsPageUrl");
        private By YourWebsitePageTextBox => By.Id("StandardInfoUrl");
        private By SaveAndContinueButton => By.Id("submit");
        private By CancelLink = By.LinkText("/10001259/standards/240");

        public YourContactInformationForThisStandardPage(ScenarioContext context) : base(context) => VerifyPage();

        public ManageAStandardPage UpdateContactInformation()
        {
            formCompletionHelper.EnterText(EmailAddressTextBox, "test@test.com");
            formCompletionHelper.EnterText(TelephoneNumberTextBox, "2213123322");
            formCompletionHelper.EnterText(ContactPageTextBox, "test.com");
            formCompletionHelper.EnterText(YourWebsitePageTextBox, "https://www.instituteforapprenticeships.org/apprenticeship-standards/advanced-carpentry-and-joinery-v1-1");
            formCompletionHelper.Click(SaveAndContinueButton);
            return new ManageAStandardPage(context);
        }
        public void ClickCancel()
        {
            formCompletionHelper.Click(CancelLink);
        }
    }
}
