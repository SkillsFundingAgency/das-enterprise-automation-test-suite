namespace SFA.DAS.FAAV2.UITests.Project.Pages.DisabilityConfident;

public class DisabilityConfidentSchemePage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Disability Confident scheme";

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

    public FAA_ApplicationOverviewPage SelectSectionCompleted()
    {
        SelectRadioOptionByForAttribute("IsSectionCompleted");
        Continue();
        return new(context);
    }
}