namespace SFA.DAS.FAAV2.UITests.Project.Helpers;

public class FAADataHelper
{
    public FAADataHelper()
    {
        var datetime = DateTime.Now;
        QualificationSubject = RandomDataGenerator.GenerateRandomAlphabeticString(5);
        QualificationGrade = RandomDataGenerator.GenerateRandomAlphabeticString(1);
        WorkExperienceEmployer = RandomDataGenerator.GenerateRandomAlphabeticString(8);
        WorkExperienceJobTitle = RandomDataGenerator.GenerateRandomAlphabeticString(15);
        WorkExperienceMainDuties = RandomDataGenerator.GenerateRandomAlphabeticString(29);
        WorkExperienceStarted = datetime.AddYears(-1).AddMonths(-10);
        TrainingCoursesCourseTitle = QualificationSubject;
        TrainingCoursesTo = datetime.AddYears(-1).AddMonths(-5);
        Strengths = RandomDataGenerator.GenerateRandomAlphabeticString(99);
        HobbiesAndInterests = RandomDataGenerator.GenerateRandomAlphabeticString(99);
        AdditionalQuestions1Answer = RandomDataGenerator.GenerateRandomAlphabeticString(59);
        AdditionalQuestions2Answer = RandomDataGenerator.GenerateRandomAlphabeticString(59);
        InterviewSupport = RandomDataGenerator.GenerateRandomAlphabeticString(22);
    }

    public string QualificationSubject { get; }

    public string QualificationGrade { get; }

    public string WorkExperienceEmployer { get; }

    public string WorkExperienceJobTitle { get; }

    public string WorkExperienceMainDuties { get; }

    public DateTime WorkExperienceStarted { get; }

    public string TrainingCoursesCourseTitle { get; }

    public DateTime TrainingCoursesTo { get; }

    public string Strengths { get; }

    public string HobbiesAndInterests { get; }

    public string AdditionalQuestions1Answer { get; }

    public string AdditionalQuestions2Answer { get; }

    public string InterviewSupport { get; }
}