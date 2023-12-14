using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApplicationFormPage(ScenarioContext context) : FAABasePage(context)
    {
        protected override string PageTitle => "Application form";

        #region
        private static By Education => By.Id("Candidate_Education_NameOfMostRecentSchoolCollege");
        private static By StartedYear => By.Id("Candidate_Education_FromYear");
        private static By FinishedYear => By.Id("Candidate_Education_ToYear");
        private static By YesQualifications => By.Id("qualifications-yes-label");
        private static By NoQualifications => By.Id("qualifications-no-label");
        private static By TypeOfQualification => By.XPath("//select[@id = 'qual-type']");
        private static By InputYear => By.Id("subject-year");
        private static By Subject => By.Id("subject-name");
        private static By Grade => By.Id("subject-grade");
        private static By SaveThisQualificationLink => By.Id("saveQualification");
        private static By YesWorkExperience => By.XPath("//label[@data-target='workexperience-panel'][contains(.,'Yes')]");
        private static By NoWorkExperience => By.XPath("//label[@for='workexp-no'][contains(.,'No')]");
        private static By Employer => By.Id("work-employer");
        private static By JobTitle => By.Id("work-title");
        private static By MainDuties => By.Id("work-role");
        private static By StartedMonth => By.Id("work-from");
        private static By FromYear => By.Id("work-from-year");
        private static By FinishedMonth => By.Id("work-to");
        private static By ToYear => By.Id("work-to-year");
        private static By SaveWorkExperience => By.Id("addWorkBtn");
        private static By YesTrainingCourse => By.Id("training-history-yes-label");
        private static By NoTrainingCourse => By.Id("training-history-no-label");
        private static By ProviderDetails => By.Id("training-history-provider");
        private static By CourseTitle => By.Id("training-history-course-title");
        private static By TrainingHistoryFromMonth => By.Id("training-history-from-month");
        private static By TrainigHistoryFromYear => By.Id("training-history-from-year");
        private static By TrainingHistoryToMonth => By.Id("training-history-to-month");
        private static By TrainingHistoryToYear => By.Id("training-history-to-year");
        private static By SaveTrainingCourse => By.Id("addTrainingCourseBtn");
        private static By FirstQuestion => By.Id("Candidate_EmployerQuestionAnswers_CandidateAnswer1");
        private static By SecondQuestion => By.Id("Candidate_EmployerQuestionAnswers_CandidateAnswer2");
        private static By Strengths => By.Id("Candidate_AboutYou_WhatAreYourStrengths");
        private static By Skills => By.Id("Candidate_AboutYou_WhatDoYouFeelYouCouldImprove");
        private static By HobbiesAndInterests => By.Id("Candidate_AboutYou_WhatAreYourHobbiesInterests");
        private static By SaveAndContinue => By.Id("apply-button");
        private static By AcceptSubmit => By.Id("AcceptSubmitLabel");
        private static By MyApplications => By.CssSelector("a#myapplications-link");
        private static By Save => By.Id("save-button");

        #endregion

        public void EnterEducation() => formCompletionHelper.EnterText(Education, faaDataHelper.EducationSchoolOrCollege);

        public void EnterStartedYear() => formCompletionHelper.EnterText(StartedYear, faaDataHelper.YearsAttended.Year.ToString());

        public void EnterFinishedYear() => formCompletionHelper.EnterText(FinishedYear, faaDataHelper.YearsAttended.Year.ToString());

        public void EnterQualificationdetails(string qualificationDetails)
        {
            if (qualificationDetails != "Yes")
            {
                formCompletionHelper.Click(NoQualifications);
            }
            else
            {
                formCompletionHelper.Click(YesQualifications);
                formCompletionHelper.SelectFromDropDownByText(TypeOfQualification, faaDataHelper.TypeOfQualification);
                formCompletionHelper.EnterText(InputYear, faaDataHelper.QualificationYear);
                formCompletionHelper.EnterText(Subject, faaDataHelper.QualificationSubject);
                formCompletionHelper.EnterText(Grade, faaDataHelper.QualificationGrade);
                formCompletionHelper.Click(SaveThisQualificationLink);
            }
        }

        public void EnterWorkExperience(string workExperience)
        {
            if (workExperience != "Yes")
            {
                formCompletionHelper.Click(NoWorkExperience);
            }
            else
            {
                formCompletionHelper.Click(YesWorkExperience);
                formCompletionHelper.EnterText(Employer, faaDataHelper.WorkExperienceEmployer);
                formCompletionHelper.EnterText(JobTitle, faaDataHelper.WorkExperienceJobTitle);
                formCompletionHelper.EnterText(MainDuties, faaDataHelper.WorkExperienceMainDuties);
                formCompletionHelper.SelectFromDropDownByValue(StartedMonth, faaDataHelper.WorkExperienceStarted.Month.ToString());
                formCompletionHelper.EnterText(FromYear, faaDataHelper.WorkExperienceStarted.Year.ToString());
                formCompletionHelper.SelectFromDropDownByValue(FinishedMonth, faaDataHelper.WorkExperienceFinished.Month.ToString());
                formCompletionHelper.EnterText(ToYear, faaDataHelper.WorkExperienceFinished.Year.ToString());
                formCompletionHelper.Click(SaveWorkExperience);
            }
        }

        public void EnterTrainingCourse(string trainingCourse)
        {
            if (trainingCourse != "Yes")
            {
                formCompletionHelper.Click(NoTrainingCourse);
            }
            else
            {
                formCompletionHelper.Click(YesTrainingCourse);
                formCompletionHelper.EnterText(ProviderDetails, faaDataHelper.TrainingCoursesProvider);
                formCompletionHelper.EnterText(CourseTitle, faaDataHelper.TrainingCoursesCourseTitle);

                formCompletionHelper.SelectFromDropDownByValue(TrainingHistoryFromMonth, faaDataHelper.TrainingCoursesFrom.Month.ToString());
                formCompletionHelper.EnterText(TrainigHistoryFromYear, faaDataHelper.TrainingCoursesFrom.Year.ToString());
                formCompletionHelper.SelectFromDropDownByValue(TrainingHistoryToMonth, faaDataHelper.TrainingCoursesTo.Month.ToString());
                formCompletionHelper.EnterText(TrainingHistoryToYear, faaDataHelper.TrainingCoursesTo.Year.ToString());
                formCompletionHelper.Click(SaveTrainingCourse);
            }
        }

        public void EnterStrengths() => formCompletionHelper.EnterText(Strengths, faaDataHelper.Strengths);

        public void EnterSkills() => formCompletionHelper.EnterText(Skills, faaDataHelper.Skills);

        public void EnterHobbiesAndInterests() => formCompletionHelper.EnterText(HobbiesAndInterests, faaDataHelper.HobbiesAndInterests);

        public void AnswerAdditionalQuestions()
        {
            if (pageInteractionHelper.IsElementDisplayed(FirstQuestion))
                formCompletionHelper.EnterText(FirstQuestion, faaDataHelper.AdditionalQuestions1);

            if (pageInteractionHelper.IsElementDisplayed(SecondQuestion))
                formCompletionHelper.EnterText(SecondQuestion, faaDataHelper.AdditionalQuestions1);
        }

        public void ClickSaveAndContinue() => formCompletionHelper.Click(SaveAndContinue);

        public void SelectAcceptSubmit() => formCompletionHelper.SendKeys(AcceptSubmit, Keys.Space);

        public FAA_ApprenticeshipApplicationSubmittedPage SubmitApprenticeshipApplication()
        {
            formCompletionHelper.ClickButtonByText("Submit application");
            return new FAA_ApprenticeshipApplicationSubmittedPage(context);
        }

        public FAA_TraineeshipApplicationSubmittedPage SubmitTraineeshipApplication()
        {
            formCompletionHelper.ClickButtonByText("Submit application", "Save and continue");
            return new FAA_TraineeshipApplicationSubmittedPage(context);
        }

        public FAA_MyApplicationsHomePage ClickSave()
        {
            formCompletionHelper.Click(Save);
            formCompletionHelper.Click(MyApplications);
            return new FAA_MyApplicationsHomePage(context);
        }
    }
}
