namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.EducationHistory;

public class SchoolCollegeAndUniversityQualificationsPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "School, college and university qualifications";
    private static By DeleteLink => By.CssSelector("a.govuk-link[href*='/qualifications/delete/']");
    private static By ConfirmDeleteButton => By.CssSelector("button.govuk-button");

    public WhatIsYourMostRecentQualificationPage SelectYesAndContinue()
    {
        ClickIfDisplayed(DeleteLink);
        ClickIfDisplayed(ConfirmDeleteButton);
        SelectRadioOptionByForAttribute("DoYouWantToAddAnyQualifications");
        Continue();
        return new(context);
    }

    public FAA_ApplicationOverviewPage SelectNoAndContinue()
    {
        SelectRadioOptionByForAttribute("DoYouWantToAddAnyQualifications-No");
        Continue();
        return new(context);
    }

}
