using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourAgreementsWithTheEducationAndSkillsFundingAgencyPage : RegistrationBasePage
    {
        protected override string PageTitle => "Your agreements with the Department for Education";

        #region Locators
        private static By UpdateTheseDetailsLink => By.LinkText("Update these details");

        private static By ExpandButton => By.CssSelector(".govuk-accordion__section-button");

        private static By AgreementId => By.CssSelector("h3.govuk-heading-l");

        private static By ViewAgreementButton => By.XPath("//*[@id='main-content']/form/input");     //By.XPath("//input[contains(text(),'View agreement')]");
        #endregion

        public YourAgreementsWithTheEducationAndSkillsFundingAgencyPage(ScenarioContext context, Action action) : base(context) => VerifyPage(PageHeader, PageTitle, action);

        public AboutYourAgreementPage GoToViewAgreement()
        {
            formCompletionHelper.ClickElement(ViewAgreementButton);
            return new AboutYourAgreementPage(context);
        }


        public ReviewYourDetailsPage ClickUpdateTheseDetailsLinkInReviewYourDetailsPage()
        {
            ShowSection();

            formCompletionHelper.Click(UpdateTheseDetailsLink);

            return new ReviewYourDetailsPage(context);
        }

        public void SetAgreementId()
        {
            var agreementId = pageInteractionHelper.GetText(AgreementId).Remove(0, 14);

            objectContext.SetAgreementId(agreementId);
        }

        public bool VerifyIfUpdateTheseDetailsLinkIsPresent()
        {
            ShowSection();

            return pageInteractionHelper.IsElementDisplayed(UpdateTheseDetailsLink);
        }

        private void ShowSection()
        {
            var e = pageInteractionHelper.FindElement(ExpandButton);

            var expand = e.GetAttribute(AttributeHelper.AriaExpanded);

            if (expand != null && expand == "false") formCompletionHelper.Click(ExpandButton);
        }
    }
}

