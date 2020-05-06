using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourAgreementsWithTheEducationAndSkillsFundingAgencyPage : RegistrationBasePage
    {
        protected override string PageTitle => "Your agreements with the Education and Skills Funding Agency";
        private readonly ScenarioContext _context;

        #region Locators
        private By UpdateTheseDetailsLink => By.LinkText("Update these details");
        private By AgreementId => By.XPath("//dd[5]");
        #endregion

        public YourAgreementsWithTheEducationAndSkillsFundingAgencyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ReviewYourDetailsPage ClickUpdateTheseDetailsLinkInReviewYourDetailsPage()
        {
            formCompletionHelper.Click(UpdateTheseDetailsLink);
            return new ReviewYourDetailsPage(_context);
        }

        public void SetAgreementId()
        {
            var agreementId = pageInteractionHelper.GetText(AgreementId);
            objectContext.SetAgreementId(agreementId);
        }

        public bool VerifyIfUpdateTheseDetailsLinkIsPresent() => pageInteractionHelper.IsElementDisplayed(UpdateTheseDetailsLink);
    }
}

