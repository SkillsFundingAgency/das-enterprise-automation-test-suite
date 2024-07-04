namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.WorkHistory;

public class VolunteeringAndWorkExperiencePage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Volunteering and work experience";

    protected override By SubmitSectionButton => By.CssSelector("button.govuk-button[type='submit']");

    public AddVolunteeringOrWorkExperiencePage SelectYesAndContinue()
    {
        SelectRadioOptionByForAttribute("DoYouWantToAddAnyVolunteeringOrWorkExperience");
        Continue();
        return new(context);
    }

    public FAA_ApplicationOverviewPage SelectNoAndContinue()
    {
        SelectRadioOptionByForAttribute("DoYouWantToAddAnyVolunteeringOrWorkExperience-false");
        Continue();
        return new(context);
    }
}