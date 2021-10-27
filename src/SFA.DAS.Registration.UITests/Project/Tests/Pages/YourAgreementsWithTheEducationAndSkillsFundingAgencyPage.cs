using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourAgreementsWithTheEducationAndSkillsFundingAgencyPage : RegistrationBasePage
    {
        protected override string PageTitle => "Your agreements with the Education and Skills Funding Agency";
        private readonly ScenarioContext _context;

        #region Locators
        private By UpdateTheseDetailsLink => By.LinkText("Update these details");
        private By AgreementId => By.CssSelector("h3.govuk-heading-l");
        #endregion

        public YourAgreementsWithTheEducationAndSkillsFundingAgencyPage(ScenarioContext context, Action action) : base(context)
        {
            _context = context;

            VerifyPage(PageHeader, PageTitle, action);
        }

        public ReviewYourDetailsPage ClickUpdateTheseDetailsLinkInReviewYourDetailsPage()
        {
            formCompletionHelper.Click(UpdateTheseDetailsLink);
            return new ReviewYourDetailsPage(_context);
        }

        public void SetAgreementId()
        {
            var agreementId = pageInteractionHelper.GetText(AgreementId).Remove(0, 14);
            objectContext.SetAgreementId(agreementId);
        }

        public bool VerifyIfUpdateTheseDetailsLinkIsPresent() => pageInteractionHelper.IsElementDisplayed(UpdateTheseDetailsLink);
    }
}

