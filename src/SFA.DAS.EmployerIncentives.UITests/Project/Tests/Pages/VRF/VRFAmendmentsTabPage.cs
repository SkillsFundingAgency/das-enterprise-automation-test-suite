using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFAmendmentsTabPage : VRFBasePage
    {
        protected override string PageTitle => "Provide amendments";

        #region Locators
        private readonly ScenarioContext _context;
        private By RemittanceEmailCheckBox => By.Id("c_rem_email");
        private By RemittanceEmailCheckBoxSelectionStatus => By.XPath("//fieldset[@id='c_rem_email']/following-sibling::i[@title='Field is valid']");
        private By ChangeBankDetailsRadioSelectionStatus => By.XPath("//fieldset[@id='change_bank']/following-sibling::i[@title='Field is valid']");
        #endregion

        public VRFAmendmentsTabPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public VRFAmendNonBankingInfoTabPage SelectChangeNonBankingInfoOptionAndContinue()
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                SelectOptionByText("change_address", "Yes");
                pageInteractionHelper.WaitForElementToBeDisplayed(RemittanceEmailCheckBox);
                SelectCheckBoxByText("c_rem_email", "remittance email");
                pageInteractionHelper.WaitForElementToBeDisplayed(RemittanceEmailCheckBoxSelectionStatus);
                SelectOptionByText("change_bank", "No");
                pageInteractionHelper.WaitForElementToBeDisplayed(ChangeBankDetailsRadioSelectionStatus);
                Continue();
            });

            return new VRFAmendNonBankingInfoTabPage(_context);
        }
    }
}
