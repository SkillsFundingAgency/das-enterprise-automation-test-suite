namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public abstract class AddOrEditOrganisationStandardBasePage : OrganisationSectionsBasePage
{
    protected static By EffectiveFromDay => By.CssSelector("#EffectiveFromDay");

    protected static By EffectiveFromMonth => By.CssSelector("#EffectiveFromMonth");

    protected static By EffectiveFromYear => By.CssSelector("#EffectiveFromYear");

    protected static By Contacts => By.CssSelector(".govuk-radios__input[name='ContactId']");

    protected static By DeliveryAreas => By.CssSelector(".govuk-checkboxes__input[name='DeliveryAreas']");

    protected static By Comments => By.CssSelector("#Comments");

    protected AddOrEditOrganisationStandardBasePage(ScenarioContext context) : base(context) => VerifyPage();

    protected void EnterEffectiveFromDetails(DateTime effectiveFrom)
    {
        formCompletionHelper.EnterText(EffectiveFromDay, effectiveFrom.Day.ToString());
        formCompletionHelper.EnterText(EffectiveFromMonth, effectiveFrom.Month.ToString());
        formCompletionHelper.EnterText(EffectiveFromYear, effectiveFrom.Year.ToString());
    }
}
