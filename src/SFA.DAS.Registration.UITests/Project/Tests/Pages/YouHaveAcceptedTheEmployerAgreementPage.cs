using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouHaveAcceptedTheEmployerAgreementPage : RegistrationBasePage
    {
        protected override string PageTitle => "You’ve accepted the employer agreement";

        #region Locators
        protected override By ContinueButton => By.LinkText("View your account");
        private static By DownloadYourAcceptedAgreementLink => By.LinkText("Download your accepted agreement");
        private static By ReviewAndAcceptYourOtherAgreementsLink => By.LinkText("review and accept your other agreements");
        #endregion

        public YouHaveAcceptedTheEmployerAgreementPage(ScenarioContext context) : base(context)
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(),
                () => VerifyPage(DownloadYourAcceptedAgreementLink)
            });
        }

        public HomePage ClickOnViewYourAccountButton()
        {
            formCompletionHelper.Click(ContinueButton);
            return new HomePage(context);
        }

        public YourOrganisationsAndAgreementsPage ClickOnReviewAndAcceptYourOtherAgreementsLink()
        {
            formCompletionHelper.Click(ReviewAndAcceptYourOtherAgreementsLink);
            return new YourOrganisationsAndAgreementsPage(context);
        }
    }
}
