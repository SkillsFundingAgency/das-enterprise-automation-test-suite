namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.EPAOWithdrawalPages;

public class AS_WhatAreYouWithdrawingFromPage : EPAO_BasePage
{
    protected override string PageTitle => "What are you withdrawing from?";

    #region Locators
    private static By AssessingASpecificStandardRaidoButton => By.CssSelector(".govuk-radios__label[for='TypeOfWithdrawal']");
    private static By TheRegisterOfEPAOrganisationsRaidoButton => By.CssSelector(".govuk-radios__label[for='TypeOfWithdrawal-organisation']");
    #endregion

    public AS_WhatAreYouWithdrawingFromPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_WhichStandardDoYouWantToWithdrawFromAssessingPage ClickAssessingASpecificStandard()
    {
        formCompletionHelper.SelectRadioOptionByLocator(AssessingASpecificStandardRaidoButton);
        Continue();
        return new(context);
    }

    public AS_CheckWithdrawalRequestPage ClickWithdrawFromRegister()
    {
        formCompletionHelper.SelectRadioOptionByLocator(TheRegisterOfEPAOrganisationsRaidoButton);
        Continue();
        return new(context);
    }
}