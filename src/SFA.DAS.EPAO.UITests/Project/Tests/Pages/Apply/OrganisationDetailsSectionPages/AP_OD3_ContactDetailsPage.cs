using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD3_ContactDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Enter contact details";
        private readonly ScenarioContext _context;

        #region Locators
        private By GivenNameTextbox => By.Id("CD-02");
        private By FamilyNameTextbox => By.Id("CD-02_1");
        private By EnterTheAddressManuallyLink => By.Id("enterAddressManually");
        private By AddressLine1Textbox => By.Id("CD-03_Key_AddressLine1");
        private By TownOrCityTextbox => By.Id("CD-03_Key_AddressLine3");
        private By CountyTextbox => By.Id("CD-03_Key_AddressLine4");
        private By PostCodeTextbox => By.Id("CD-03_Key_Postcode");
        private By EmailAddressTextbox => By.Id("CD-05");
        private By TelephoneTextbox => By.Id("CD-06");
        #endregion

        public AP_OD3_ContactDetailsPage(ScenarioContext context) : base(context)
        {   
            _context = context;
            VerifyPage();
        }
        
        public AP_OD4_ContractNoticeToPage EnterContactDetailsAndContinueInContactDetailsPage()
        {
            formCompletionHelper.EnterText(GivenNameTextbox, dataHelper.GetRandomAlphabeticString(10));
            formCompletionHelper.EnterText(FamilyNameTextbox, dataHelper.GetRandomAlphabeticString(10));
            formCompletionHelper.Click(EnterTheAddressManuallyLink);
            formCompletionHelper.EnterText(AddressLine1Textbox, dataHelper.GetRandomNumber(3));
            formCompletionHelper.EnterText(TownOrCityTextbox, dataHelper.GetTownName);
            formCompletionHelper.EnterText(CountyTextbox, dataHelper.GetCountyName);
            formCompletionHelper.EnterText(PostCodeTextbox, dataHelper.GetPostCode);
            formCompletionHelper.EnterText(EmailAddressTextbox, dataHelper.GetRandomEmail);
            formCompletionHelper.EnterText(TelephoneTextbox, dataHelper.GetRandomNumber(10));
            Continue();
            return new AP_OD4_ContractNoticeToPage(_context);
        }
    }
}
