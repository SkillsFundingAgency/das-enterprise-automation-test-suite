namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AS_WhatAreYouWithdrawingFromPage : EPAO_BasePage
{
    protected override string PageTitle => "What are you withdrawing from?";

    #region Locators
    private static By AssessingASpecificStandardRaidoButton => By.XPath("//*[@id='TypeOfWithdrawal']");
    private static By TheRegisterOfEPAOrganisationsRaidoButton => By.Id("TypeOfWithdrawal-2");
    #endregion

    public AS_WhatAreYouWithdrawingFromPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WhichStandardDoYouWantToWithdrawFromAssessingPage ClickAssessingASpecificStandard()
    {
        formCompletionHelper.SelectRadioOptionByLocator(AssessingASpecificStandardRaidoButton);
        Continue();
        return new AS_WhichStandardDoYouWantToWithdrawFromAssessingPage(context);
    }

    public AS_CheckWithdrawalRequestPage ClickWithdrawFromRegister()
    {
        formCompletionHelper.SelectRadioOptionByLocator(TheRegisterOfEPAOrganisationsRaidoButton);
        Continue();
        return new AS_CheckWithdrawalRequestPage(context);
    }
}
