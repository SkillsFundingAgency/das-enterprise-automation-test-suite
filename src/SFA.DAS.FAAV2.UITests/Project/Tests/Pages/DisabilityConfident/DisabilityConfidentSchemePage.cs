namespace SFA.DAS.FAAV2.UITests.Project.Tests.Pages.DisabilityConfident;

public class DisabilityConfidentSchemePage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Disability Confident scheme";

    protected override By SubmitSectionButton => By.CssSelector("button.govuk-button[type='submit']");

    public DisabilityConfidentSchemePage SelectYesAndContinue()
    {
        SelectRadioOptionByForAttribute("ApplyUnderDisabilityConfidentScheme");
        Continue();
        return new(context);
    }

    public DisabilityConfidentSchemePage SelectNoAndContinue()
    {
        SelectRadioOptionByForAttribute("ApplyUnderDisabilityConfidentScheme-No");
        Continue();
        return new(context);
    }
}