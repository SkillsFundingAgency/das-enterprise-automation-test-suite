using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages
{
    public class AS_WhatAreYouWithdrawingFromPage : EPAO_BasePage
    {
        protected override string PageTitle => "What are you withdrawing from?";
        private readonly ScenarioContext _context;

        #region Locators
        private By AssessingASpecificStandardRaidoButton => By.XPath("//*[@id='TypeOfWithdrawal']");
        private By TheRegisterOfEPAOrganisationsRaidoButton => By.Id("TypeOfWithdrawal-2");
        private By SelectWithdrawalApplicationStartButton => By.LinkText("Start");
        #endregion
        public AS_WhatAreYouWithdrawingFromPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public AS_WhichStandardDoYouWantToWithdrawFromAssessingPage ClickAssessingASpecificStandard()
        {
            formCompletionHelper.SelectRadioOptionByLocator(AssessingASpecificStandardRaidoButton);
            Continue();
            return new AS_WhichStandardDoYouWantToWithdrawFromAssessingPage(_context);
        }

        public AS_ApplicationOverviewPage ClickWithdrawFromRegister()
        {
            formCompletionHelper.SelectRadioOptionByLocator(TheRegisterOfEPAOrganisationsRaidoButton);
            Continue();
            return new AS_ApplicationOverviewPage(_context);
        }
    }
}
