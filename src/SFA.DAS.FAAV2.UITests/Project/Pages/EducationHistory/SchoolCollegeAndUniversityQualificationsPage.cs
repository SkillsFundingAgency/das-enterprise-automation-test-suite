namespace SFA.DAS.FAAV2.UITests.Project.Pages.EducationHistory;

public class SchoolCollegeAndUniversityQualificationsPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "School, college and university qualifications";

    public WhatIsYourMostRecentQualificationPage SelectYesAndContinue()
    {
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

    public FAA_ApplicationOverviewPage SelectSectionCompleted()
    {
        SelectRadioOptionByForAttribute("IsSectionCompleted");
        Continue();
        return new(context);
    }

}
