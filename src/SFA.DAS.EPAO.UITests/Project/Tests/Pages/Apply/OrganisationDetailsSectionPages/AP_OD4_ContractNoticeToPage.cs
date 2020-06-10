using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages
{
    public class AP_OD4_ContractNoticeToPage : EPAO_BasePage
    {
        protected override string PageTitle => "Who should we send the contract notice to?";
        private readonly ScenarioContext _context;

        #region Locators
        private By GivenNameTextbox => By.Id("CD-07");
        private By FamilyNameTextbox => By.Id("CD-07_1");
        private By EnterTheAddressManuallyLink => By.Id("enterAddressManually");
        private By AddressLine1Textbox => By.Id("CD-08_Key_AddressLine1");
        private By TownOrCityTextbox => By.Id("CD-08_Key_AddressLine3");
        private By CountyTextbox => By.Id("CD-08_Key_AddressLine4");
        private By PostCodeTextbox => By.Id("CD-08_Key_Postcode");
        private By EmailAddressTextbox => By.Id("CD-10");
        private By TelephoneTextbox => By.Id("CD-11");
        #endregion

        public AP_OD4_ContractNoticeToPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_OD5_UkprnPage EnterContactDetailsAndContinueInContractNoticeToPage()
        {
            formCompletionHelper.EnterText(GivenNameTextbox, ePAOApplyDataHelper.GetRandomAlphabeticString(10));
            formCompletionHelper.EnterText(FamilyNameTextbox, ePAOApplyDataHelper.GetRandomAlphabeticString(10));
            formCompletionHelper.Click(EnterTheAddressManuallyLink);
            formCompletionHelper.EnterText(AddressLine1Textbox, ePAOApplyDataHelper.GetRandomNumber(3));
            formCompletionHelper.EnterText(TownOrCityTextbox, ePAOApplyDataHelper.TownName);
            formCompletionHelper.EnterText(CountyTextbox, ePAOApplyDataHelper.CountyName);
            formCompletionHelper.EnterText(PostCodeTextbox, ePAOApplyDataHelper.PostCode);
            formCompletionHelper.EnterText(EmailAddressTextbox, ePAOApplyDataHelper.RandomEmail);
            formCompletionHelper.EnterText(TelephoneTextbox, ePAOApplyDataHelper.GetRandomNumber(10));
            Continue();
            return new AP_OD5_UkprnPage(_context);
        }
    }
}
