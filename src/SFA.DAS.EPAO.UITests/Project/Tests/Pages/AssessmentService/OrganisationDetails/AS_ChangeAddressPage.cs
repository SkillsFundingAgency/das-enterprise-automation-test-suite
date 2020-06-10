using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails
{
    public class AS_ChangeAddressPage : EPAO_BasePage
    {
        protected override string PageTitle => "Change address";
        private readonly ScenarioContext _context;

        #region Locators
        private By SearchForANewAddressLink => By.Id("searchAgain");
        private By EnterTheAddressManuallyLink => By.Id("enterAddressManually");
        private By AddressLine1TextBox => By.Id("AddressLine1");
        private By AddressLine2TextBox => By.Id("AddressLine2");
        private By TownOrCityTextBox => By.Id("AddressLine3");
        private By PostCodeTextBox => By.Id("Postcode");
        #endregion

        public AS_ChangeAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ChangeAddressPage ClickSearchForANewAddressLink()
        {
            formCompletionHelper.Click(SearchForANewAddressLink);
            return this;
        }

        public AS_ChangeAddressPage ClickEnterTheAddressManuallyLink()
        {
            formCompletionHelper.Click(EnterTheAddressManuallyLink);
            return this;
        }

        public AS_ConfirmContactAddressPage EnterEmployerAddressAndClickChangeAddressButton()
        {
            formCompletionHelper.EnterText(AddressLine1TextBox, ePAOAssesmentServiceDataHelper.GetRandomNumber(3));
            formCompletionHelper.EnterText(AddressLine2TextBox, "QuintonRoad");
            formCompletionHelper.EnterText(TownOrCityTextBox, "Coventry");
            formCompletionHelper.EnterText(PostCodeTextBox, "CV1 2WT");
            Continue();
            return new AS_ConfirmContactAddressPage(_context);
        }
    }

    public class AS_ConfirmContactAddressPage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm contact address";
        private readonly ScenarioContext _context;

        public AS_ConfirmContactAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ContactAddressUpdatedPage ClickConfirmAddressButtonInConfirmContactAddressPage()
        {
            Continue();
            return new AS_ContactAddressUpdatedPage(_context);
        }
    }

    public class AS_ContactAddressUpdatedPage : AS_ChangeOrgDetailsBasePage
    {
        protected override string PageTitle => "Contact address updated";

        public AS_ContactAddressUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}