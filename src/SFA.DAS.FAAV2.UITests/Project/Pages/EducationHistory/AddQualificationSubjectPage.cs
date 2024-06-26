namespace SFA.DAS.FAAV2.UITests.Project.Pages.EducationHistory;

public class AddQualificationSubjectPage : FAABasePage
{
    protected override string PageTitle => _pageTitle;

    private readonly string _pageTitle;

    private static By Subject => By.CssSelector("#Subjects[0].Name");

    private static By Grade => By.CssSelector("#Subjects[0].Grade");

    private static By SubjectLevel => By.CssSelector("#Subjects[0].Level");

    public AddQualificationSubjectPage(ScenarioContext context, string qualification) : base(context, false)
    {
        _pageTitle = qualification;

        VerifyPage();
    }

    public SchoolCollegeAndUniversityQualificationsPage AddQualificationDetailsAndContinue()
    {
        formCompletionHelper.EnterText(Subject, faaDataHelper.QualificationSubject);

        formCompletionHelper.EnterText(Grade, faaDataHelper.QualificationGrade);

        if (_pageTitle.CompareToIgnoreCase("btec"))
        {
            formCompletionHelper.SelectFromDropDownByText(SubjectLevel, "Level 2");
        }

        formCompletionHelper.ClickButtonByText(ContinueButton, "Save and continue");

        return new(context);
    }
}
