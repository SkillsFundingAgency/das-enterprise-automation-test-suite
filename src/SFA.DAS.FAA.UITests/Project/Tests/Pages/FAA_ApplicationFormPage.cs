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
        private By MyApplications => By.CssSelector("#myapplications-link");
        private By Save => By.Id("save-button");


        #endregion

        public FAA_ApplicationFormPage(ScenarioContext context) : base(context) => _context = context;

        public void EnterEducation()
        {
            _formCompletionHelper.EnterText(Education, _faadataHelper.EducationSchoolOrCollege);
        }

        public void EnterStartedYear()
        {
            _formCompletionHelper.EnterText(StartedYear, _faadataHelper.YearsAttended.Year.ToString());
        }

        public void EnterFinishedYear()
        {
            _formCompletionHelper.EnterText(FinishedYear, _faadataHelper.YearsAttended.Year.ToString());
        }

        public void EnterQualificationdetails(string qualificationDetails)
        {
            if (qualificationDetails != "Yes")
            {
                _formCompletionHelper.Click(NoQualifications);
            }
            else
            {
                _formCompletionHelper.Click(YesQualifications);
                _formCompletionHelper.SelectFromDropDownByText(TypeOfQualification, _faadataHelper.TypeOfQualification);
                _formCompletionHelper.EnterText(InputYear, _faadataHelper.QualificationYear);
                _formCompletionHelper.EnterText(Subject, _faadataHelper.QualificationSubject);
                _formCompletionHelper.EnterText(Grade, _faadataHelper.QualificationGrade);
                _formCompletionHelper.Click(SaveThisQualificationLink);
            }
        }

        public void EnterWorkExperience(string workExperience)
        {
            if (workExperience != "Yes")
            {
                _formCompletionHelper.Click(NoWorkExperience);
            }
            else
            {
                _formCompletionHelper.Click(YesWorkExperience);
                _formCompletionHelper.EnterText(Employer, _faadataHelper.WorkExperienceEmployer);
                _formCompletionHelper.EnterText(JobTitle, _faadataHelper.WorkExperienceJobTitle);
                _formCompletionHelper.EnterText(MainDuties, _faadataHelper.WorkExperienceMainDuties);
                _formCompletionHelper.SelectFromDropDownByValue(StartedMonth, _faadataHelper.WorkExperienceStarted.Month.ToString());
                _formCompletionHelper.EnterText(FromYear, _faadataHelper.WorkExperienceStarted.Year.ToString());
                _formCompletionHelper.SelectFromDropDownByValue(FinishedMonth, _faadataHelper.WorkExperienceFinished.Month.ToString());
                _formCompletionHelper.EnterText(ToYear, _faadataHelper.WorkExperienceFinished.Year.ToString());
                _formCompletionHelper.Click(SaveWorkExperience);
            }
        }

        public void EnterTrainingCourse(string trainingCourse)
        {
            if (trainingCourse != "Yes")
            {
                _formCompletionHelper.Click(NoTrainingCourse);
            }
            else
            {
                _formCompletionHelper.Click(YesTrainingCourse);
                _formCompletionHelper.EnterText(ProviderDetails, _faadataHelper.TrainingCoursesProvider);
                _formCompletionHelper.EnterText(CourseTitle, _faadataHelper.TrainingCoursesCourseTitle);

                _formCompletionHelper.SelectFromDropDownByValue(TrainingHistoryFromMonth, _faadataHelper.TrainingCoursesFrom.Month.ToString());
                _formCompletionHelper.EnterText(TrainigHistoryFromYear, _faadataHelper.TrainingCoursesFrom.Year.ToString());
                _formCompletionHelper.SelectFromDropDownByValue(TrainingHistoryToMonth, _faadataHelper.TrainingCoursesTo.Month.ToString());
                _formCompletionHelper.EnterText(TrainingHistoryToYear, _faadataHelper.TrainingCoursesTo.Year.ToString());
                _formCompletionHelper.Click(SaveTrainingCourse);
            }
        }

        public void EnterStrengths()
        {
            _formCompletionHelper.EnterText(Strengths, _faadataHelper.Strengths);
        }

        public void EnterSkills()
        {
            _formCompletionHelper.EnterText(Skills, _faadataHelper.Skills);
        }

        public void EnterHobbiesAndInterests()
        {
            _formCompletionHelper.EnterText(HobbiesAndInterests, _faadataHelper.HobbiesAndInterests);
        }

        public void AnswerAdditionalQuestions()
        {
            if (_pageInteractionHelper.IsElementDisplayed(FirstQuestion))
            {
                _formCompletionHelper.EnterText(FirstQuestion, _faadataHelper.AdditionalQuestions1);
            }
            if (_pageInteractionHelper.IsElementDisplayed(SecondQuestion))
            {
                _formCompletionHelper.EnterText(SecondQuestion, _faadataHelper.AdditionalQuestions1);
            }
        }

        public void ClickSaveAndContinue()
        {
            _formCompletionHelper.Click(SaveAndContinue);
        }

        public void SelectAcceptSubmit()
        {
            _formCompletionHelper.SendKeys(AcceptSubmit, Keys.Space);
        }

        public FAA_ApprenticeshipApplicationSubmittedPage SubmitApprenticeshipApplication()
        {
            _formCompletionHelper.ClickButtonByText("Submit application");
            return new FAA_ApprenticeshipApplicationSubmittedPage(_context);
        }

        public FAA_TraineeshipApplicationSubmittedPage SubmitTraineeshipApplication()
        {
            _formCompletionHelper.ClickButtonByText("Submit application", "Save and continue");
            return new FAA_TraineeshipApplicationSubmittedPage(_context);
        }

        public void ClickSignOut()
        {
            _formCompletionHelper.Click(SignOut);
        }

        public void GoToMyApplications()
        {
            if (_pageInteractionHelper.IsElementDisplayed(MyApplications))
            {
                _formCompletionHelper.Click(MyApplications);
            }
        }

        public FAA_MyApplicationsHomePage ClickSave()
        {
            _formCompletionHelper.Click(Save);
            GoToMyApplications();
            return new FAA_MyApplicationsHomePage(_context);
        }
    }
}
