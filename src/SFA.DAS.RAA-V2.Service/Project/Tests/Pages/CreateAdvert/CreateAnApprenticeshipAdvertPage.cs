using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public partial class CreateAnApprenticeshipAdvertOrVacancyPage : Raav2BasePage
    {
        protected override string PageTitle => IsTraineeship ? "Create a traineeship vacancy" :(isRaaV2Employer ? "Create an apprenticeship advert" : "Create an apprenticeship vacancy");

        protected override By TaskName => By.CssSelector(".das-task-list__item .govuk-link");

        private By ReturnToApplicationsSelector => By.LinkText("Return to your applications");

        public CreateAnApprenticeshipAdvertOrVacancyPage(ScenarioContext context) : base(context) { }

        public void ReturnToApplications() => formCompletionHelper.ClickElement(ReturnToApplicationsSelector);
    
        public CheckYourAnswersPage CheckYourAnswers()
        {
            NavigateToTask(Checkandsubmityouradvert, Checkandsubmityouradvert_1);
            return new CheckYourAnswersPage(context);
        }

        public WhichEmployerNameDoYouWantOnYourAdvertPage EmployerName()
        {
            NavigateToTask(Abouttheemployer, Abouttheemployer_1);
            return new WhichEmployerNameDoYouWantOnYourAdvertPage(context);
        }

        public DesiredSkillsPage Skills()
        {
            NavigateToTask(Skillsandqualifications, Skillsandqualifications_1);
            return new DesiredSkillsPage(context);
        }

        public ImportantDatesPage ImportantDates()
        {
            NavigateToTask(Employmentdetails, Employmentdetails_1);
            return new ImportantDatesPage(context);
        }

        public WhatDoYouWantToCallThisAdvertPage AdvertTitle()
        {
            NavigateToAdvertTitle();
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }
        
        public void NavigateToAdvertTitle() => NavigateToTask(AdvertOrVacancysummary, AdvertOrVacancysummary_1);

        public SelectOrganisationPage EnterAdvertOrganisaition()
        {
            NavigateToTask(AdvertOrVacancysummary, AdvertOrVacancysummary_2);
            return new SelectOrganisationPage(context);
        }
        public ApprenticeshipTrainingPage EnterAdvertTrainingCourse()
        {
            NavigateToTask(AdvertOrVacancysummary, AdvertOrVacancysummary_3);
            return new ApprenticeshipTrainingPage(context);
        }

        public WhatDoYouWantToCallThisAdvertPage EnterAdvertTrainingProvider()
        {
            NavigateToTask(AdvertOrVacancysummary, Advertsummary_4);
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }

        public WhatDoYouWantToCallThisAdvertPage EnterAdvertSummary()
        {
            NavigateToTask(AdvertOrVacancysummary, AdvertOrVacancysummary_5);
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }

        public WhatDoYouWantToCallThisAdvertPage EnterAdvertAbout()
        {
            NavigateToTask(AdvertOrVacancysummary, AdvertOrVacancysummary_6);
            return new WhatDoYouWantToCallThisAdvertPage(context);
        }

        public void VerifyAdvertSummarySectionStatus(string status) => VerifySectionStatus(AdvertOrVacancysummary, status);

        public void VerifyEmploymentDetailsSectionStatus(string status) => VerifySectionStatus(Employmentdetails, status);

        public void VerifySkillsandqualificationsSectionStatus(string status) => VerifySectionStatus(Skillsandqualifications, status);

        public void VerifyAbouttheemployerSectionStatus(string status) => VerifySectionStatus(Abouttheemployer, status);

        public void VerifyCheckandsubmityouradvertSectionStatus(string status) => VerifySectionStatus(Checkandsubmityouradvert, status);

        public void VerifySectionStatus(string sectionName, string status) => VerifySectionStatus(sectionName, status, null);

        private void NavigateToTask(string sectionName, string taskName, int index = 0) => NavigateToTask(sectionName, taskName, index, null);
    }
}
