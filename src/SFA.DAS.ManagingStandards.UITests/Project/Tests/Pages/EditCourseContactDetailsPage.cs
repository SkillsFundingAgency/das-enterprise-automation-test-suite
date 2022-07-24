using OpenQA.Selenium;
using SFA.DAS.ManagingStandards.UITests.Project.Tests.Helpers;
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
        protected override string PageTitle => "Your contact information for this standard";
        protected readonly ManagingStandardsDataHelpers managingStandardsDataHelpers;

        private By EmailAddressTextBox => By.Id("ContactUsEmail");
        private By TelephoneNumberTextBox => By.Id("ContactUsPhoneNumber");
        private By ContactPageTextBox => By.Id("ContactUsPageUrl");
        private By YourWebsitePageTextBox => By.Id("StandardInfoUrl");
        private By SaveAndContinueButton => By.Id("submit");

        public YourContactInformationForThisStandardPage(ScenarioContext context) : base(context)
        {
            managingStandardsDataHelpers = new ManagingStandardsDataHelpers();
            VerifyPage();
        }

        public ManageAStandard_DevopsPage UpdateContactInformation()
        {
            formCompletionHelper.EnterText(EmailAddressTextBox, managingStandardsDataHelpers.EmailAddress);
            formCompletionHelper.EnterText(TelephoneNumberTextBox, managingStandardsDataHelpers.ContactNumber);
            formCompletionHelper.EnterText(ContactPageTextBox, managingStandardsDataHelpers.ContactWebsite);
            formCompletionHelper.EnterText(YourWebsitePageTextBox, managingStandardsDataHelpers.Website);
            formCompletionHelper.Click(SaveAndContinueButton);
            return new ManageAStandard_DevopsPage(context);
        }

    }
}
