using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApplicationFormPage : FAABasePage
    {
        protected override string PageTitle => "Application form";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region
        private By ApplicationFormHeading => By.Id("appTourStart");
        private By Education => By.Id("Candidate_Education_NameOfMostRecentSchoolCollege");
        private By StartedYear => By.Id("Candidate_Education_FromYear");
        private By FinishedYear => By.Id("Candidate_Education_ToYear");
        private By YesQualifications => By.Id("qualifications-yes-label");
        private By NoQualifications => By.Id("qualifications-no-label");
        private By TypeOfQualification => By.XPath("//select[@id = 'qual-type']");
        private By InputYear => By.Id("subject-year");
        private By Subject => By.Id("subject-name");
        private By Grade => By.Id("subject-grade");
        private By SaveThisQualificationLink => By.Id("saveQualification");
        private By YesWorkExperience => By.XPath("//label[@data-target='workexperience-panel'][contains(.,'Yes')]");
        private By NoWorkExperience => By.XPath("//label[@for='workexp-no'][contains(.,'No')]");
        private By Employer => By.Id("work-employer");
        private By JobTitle => By.Id("work-title");
        private By MainDuties => By.Id("work-role");
        private By StartedMonth => By.Id("work-from");
        private By FromYear => By.Id("work-from-year");
        private By FinishedMonth => By.Id("work-to");
        private By ToYear => By.Id("work-to-year");
        private By SaveWorkExperience => By.Id("addWorkBtn");
        private By YesTrainingCourse => By.Id("training-history-yes-label");
        private By NoTrainingCourse => By.Id("training-history-no-label");
        private By ProviderDetails => By.Id("training-history-provider");
        private By CourseTitle => By.Id("training-history-course-title");
        private By TrainingHistoryFromMonth => By.Id("training-history-from-month");
        private By TrainigHistoryFromYear => By.Id("training-history-from-year");
        private By TrainingHistoryToMonth => By.Id("training-history-to-month");
        private By TrainingHistoryToYear => By.Id("training-history-to-year");
        private By SaveTrainingCourse => By.Id("addTrainingCourseBtn");
        private By FirstQuestion => By.Id("Candidate_EmployerQuestionAnswers_CandidateAnswer1");
        private By SecondQuestion => By.Id("Candidate_EmployerQuestionAnswers_CandidateAnswer2");
        private By Strengths => By.Id("Candidate_AboutYou_WhatAreYourStrengths");
        private By Skills => By.Id("Candidate_AboutYou_WhatDoYouFeelYouCouldImprove");
        private By HobbiesAndInterests => By.Id("Candidate_AboutYou_WhatAreYourHobbiesInterests");
        private By SaveAndContinue => By.Id("apply-button");
        private By AcceptSubmit => By.Id("AcceptSubmitLabel");
        private By SignOut => By.XPath("//a[contains(.,'Sign out')]");
        private By MyApplications => By.CssSelector("a#myapplications-link");
        private By Save => By.Id("save-button");


        #endregion

        public FAA_ApplicationFormPage(ScenarioContext context) : base(context) => _context = context;

        public void EnterEducation()
        {
            formCompletionHelper.EnterText(Education, faadataHelper.EducationSchoolOrCollege);
        }

        public void EnterStartedYear()
        {
            formCompletionHelper.EnterText(StartedYear, faadataHelper.YearsAttended.Year.ToString());
        }

        public void EnterFinishedYear()
        {
            formCompletionHelper.EnterText(FinishedYear, faadataHelper.YearsAttended.Year.ToString());
        }

        public void EnterQualificationdetails(string qualificationDetails)
        {
            if (qualificationDetails != "Yes")
            {
                formCompletionHelper.Click(NoQualifications);
            }
            else
            {
                formCompletionHelper.Click(YesQualifications);
                formCompletionHelper.SelectFromDropDownByText(TypeOfQualification, faadataHelper.TypeOfQualification);
                formCompletionHelper.EnterText(InputYear, faadataHelper.QualificationYear);
                formCompletionHelper.EnterText(Subject, faadataHelper.QualificationSubject);
                formCompletionHelper.EnterText(Grade, faadataHelper.QualificationGrade);
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
                formCompletionHelper.EnterText(Employer, faadataHelper.WorkExperienceEmployer);
                formCompletionHelper.EnterText(JobTitle, faadataHelper.WorkExperienceJobTitle);
                formCompletionHelper.EnterText(MainDuties, faadataHelper.WorkExperienceMainDuties);
                formCompletionHelper.SelectFromDropDownByValue(StartedMonth, faadataHelper.WorkExperienceStarted.Month.ToString());
                formCompletionHelper.EnterText(FromYear, faadataHelper.WorkExperienceStarted.Year.ToString());
                formCompletionHelper.SelectFromDropDownByValue(FinishedMonth, faadataHelper.WorkExperienceFinished.Month.ToString());
                formCompletionHelper.EnterText(ToYear, faadataHelper.WorkExperienceFinished.Year.ToString());
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
                formCompletionHelper.EnterText(ProviderDetails, faadataHelper.TrainingCoursesProvider);
                formCompletionHelper.EnterText(CourseTitle, faadataHelper.TrainingCoursesCourseTitle);

                formCompletionHelper.SelectFromDropDownByValue(TrainingHistoryFromMonth, faadataHelper.TrainingCoursesFrom.Month.ToString());
                formCompletionHelper.EnterText(TrainigHistoryFromYear, faadataHelper.TrainingCoursesFrom.Year.ToString());
                formCompletionHelper.SelectFromDropDownByValue(TrainingHistoryToMonth, faadataHelper.TrainingCoursesTo.Month.ToString());
                formCompletionHelper.EnterText(TrainingHistoryToYear, faadataHelper.TrainingCoursesTo.Year.ToString());
                formCompletionHelper.Click(SaveTrainingCourse);
            }
        }

        public void EnterStrengths()
        {
            formCompletionHelper.EnterText(Strengths, faadataHelper.Strengths);
        }

        public void EnterSkills()
        {
            formCompletionHelper.EnterText(Skills, faadataHelper.Skills);
        }

        public void EnterHobbiesAndInterests()
        {
            formCompletionHelper.EnterText(HobbiesAndInterests, faadataHelper.HobbiesAndInterests);
        }

        public void AnswerAdditionalQuestions()
        {
            if (pageInteractionHelper.IsElementDisplayed(FirstQuestion))
            {
                formCompletionHelper.EnterText(FirstQuestion, faadataHelper.AdditionalQuestions1);
            }
            if (pageInteractionHelper.IsElementDisplayed(SecondQuestion))
            {
                formCompletionHelper.EnterText(SecondQuestion, faadataHelper.AdditionalQuestions1);
            }
        }

        public void ClickSaveAndContinue()
        {
            formCompletionHelper.Click(SaveAndContinue);
        }

        public void SelectAcceptSubmit()
        {
            formCompletionHelper.SendKeys(AcceptSubmit, Keys.Space);
        }

        public FAA_ApprenticeshipApplicationSubmittedPage SubmitApprenticeshipApplication()
        {
            formCompletionHelper.ClickButtonByText("Submit application");
            return new FAA_ApprenticeshipApplicationSubmittedPage(_context);
        }

        public FAA_TraineeshipApplicationSubmittedPage SubmitTraineeshipApplication()
        {
            formCompletionHelper.ClickButtonByText("Submit application", "Save and continue");
            return new FAA_TraineeshipApplicationSubmittedPage(_context);
        }

        public FAA_MyApplicationsHomePage ClickSave()
        {
            formCompletionHelper.Click(Save);
            formCompletionHelper.Click(MyApplications);
            return new FAA_MyApplicationsHomePage(_context);
        }
    }
}
