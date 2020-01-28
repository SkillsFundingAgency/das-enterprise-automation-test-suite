using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD5_EnterContactDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Enter contact details";
        private readonly ScenarioContext _context;

        #region Locators
        private By GivenNameTextbox => By.Id("CD-02");
        private By FamilyNameTextbox => By.Id("CD-02_1");
        private By EmailAddressTextbox => By.Id("CD-05");
        private By TelephoneTextbox => By.Id("CD-06");
        private By EnterTheAddressManuallyLink => By.Id("enterAddressManually");
        private By AddressLine1Textbox => By.Id("CD-03_Key_AddressLine1");
        private By TownOrCityTextbox => By.Id("CD-03_Key_AddressLine3");
        private By CountyTextbox => By.Id("CD-03_Key_AddressLine4");
        private By PostCodeTextbox => By.Id("CD-03_Key_Postcode");

        #endregion

        public AP_OD5_EnterContactDetailsPage(ScenarioContext context) : base(context)
        {   
            _context = context;
            VerifyPage();
        }

        public AP_OD6_WhoShouldWeSendContractNoticeToPage EnterContactDetailsAndClickContinueInEnterContactDetailsPage()
        {
            formCompletionHelper.EnterText(GivenNameTextbox, dataHelper.GetGivenName);
            formCompletionHelper.EnterText(FamilyNameTextbox, dataHelper.GetFamilyName);
            formCompletionHelper.Click(EnterTheAddressManuallyLink);
            formCompletionHelper.EnterText(AddressLine1Textbox, dataHelper.GetRandomAddressLine1);
            formCompletionHelper.EnterText(TownOrCityTextbox, dataHelper.GetTownName);
            formCompletionHelper.EnterText(CountyTextbox, dataHelper.GetCountyName);
            formCompletionHelper.EnterText(PostCodeTextbox, dataHelper.GetPostCode);
            formCompletionHelper.EnterText(EmailAddressTextbox, dataHelper.GetRandomEmail);
            formCompletionHelper.EnterText(TelephoneTextbox, dataHelper.Get10DigitRandomNumber);
            Continue();
            return new AP_OD6_WhoShouldWeSendContractNoticeToPage(_context);
        }
    }
}
