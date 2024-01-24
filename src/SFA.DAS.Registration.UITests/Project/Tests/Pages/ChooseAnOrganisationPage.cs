using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChooseAnOrganisationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Choose your organisation";

        #region Locators
        protected override By RadioLabels => By.CssSelector("label");
        protected override By ContinueButton => By.Id("submit-organisation-button");
        #endregion

        public ChooseAnOrganisationPage(ScenarioContext context) : base(context) => VerifyPage();

        public CheckYourDetailsPage SelectFirstOrganisationAndContinue()
        {
            SelectRadioOptionByText(objectContext.GetOrganisationName());
            Continue();
            return new CheckYourDetailsPage(context);
        }
    }
}