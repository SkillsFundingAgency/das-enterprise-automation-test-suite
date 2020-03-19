using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class DynamicHomePage : HomePage
    {

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly VacancyTitleDatahelper _vacancyTitleDataHelper;
        private readonly RAAV2DataHelper _raaV2DataHelper;
        #endregion
       
        private By ContinueCreatingNewVacancy => By.LinkText("Continue creating your vacancy");
        private By GotoYourVacancyDashboard => By.LinkText("Go to your vacancy dashboard");
        private By ReviewYourVacancy => By.LinkText("Review your vacancy");
        private By ApplicationsLink => By.CssSelector(".govuk-link");
        private By AddApprenticeDetails => By.LinkText("Add apprentice details");
        private By TRows => By.CssSelector("tr");
        private By THeader => By.CssSelector("th");
        private By TData => By.CssSelector("td");


        public DynamicHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            _raaV2DataHelper = context.Get<RAAV2DataHelper>();
        }

        private IWebElement GetDetails(string headerName)
        {
            foreach (var row in pageInteractionHelper.FindElements(TRows))
            {
                if (row.FindElement(THeader).Text.ContainsCompareCaseInsensitive(headerName))
                {
                    return row.FindElement(TData);
                }
            }
            throw new NotFoundException($"{headerName} not found");
        }

        private void ConfirmVacancyTitleAndStatus(string status)
        {
            string vacancyStatus = GetDetails("Status").Text.ToString();
            pageInteractionHelper.VerifyText(GetDetails("Title").Text.ToString(), _vacancyTitleDataHelper.VacancyTitle);
            pageInteractionHelper.VerifyText(vacancyStatus, status);
        }

        private void ConfirmSubmittedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            pageInteractionHelper.VerifyText(GetDetails("Closing date").Text.ToString(), _raaV2DataHelper.VacancyClosing.ToString("dd MMM yyyy"));
            pageInteractionHelper.VerifyText(GetDetails("Applications").Text.ToString(), "application");
        }

        private void ConfirmRejectedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
        }

        private void ConfirmLiveVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            pageInteractionHelper.VerifyText(GetDetails("Closing date").Text.ToString(), _raaV2DataHelper.VacancyClosing.ToString("dd MMM yyyy"));
            pageInteractionHelper.VerifyText(GetDetails("Applications").Text.ToString(), "application"); 
            if (!pageInteractionHelper.IsElementDisplayed(AddApprenticeDetails))
            {
                throw new Exception("Add apprenticedetails not found");
            }
        }

        private void ConfirmClosedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            pageInteractionHelper.VerifyText(GetDetails("Closing date").Text.ToString(), DateTime.Today.ToString("dd MMMM yyyy"));
            pageInteractionHelper.VerifyText(GetDetails("Applications").Text.ToString(), "application");
            if(!pageInteractionHelper.IsElementDisplayed(AddApprenticeDetails))
            {
                throw new Exception("Add apprenticedetails not found");
            }
        }

        public VacancyPreviewPart2Page ConfirmDraftVacancyDetailsAndClickContinueCreatingYourVacancy(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            formCompletionHelper.Click(ContinueCreatingNewVacancy);
            return new VacancyPreviewPart2Page(_context);
        }

        public RecruitmentHomePage ConfirmSubmittedVacancyDetailsAndClickGoToYourVacancyDashboard(string status)
        {
            ConfirmSubmittedVacancyDetails(status);
            formCompletionHelper.Click(GotoYourVacancyDashboard);
            return new RecruitmentHomePage(_context);
        }

        public VacancyPreviewPart2Page ConfirmRejectedVacancyDetailsAndClickReviewYourVacancy(string status)
        {
            pageInteractionHelper.RefreshPage();
            ConfirmRejectedVacancyDetails(status);
            formCompletionHelper.Click(ReviewYourVacancy);
            return new VacancyPreviewPart2Page(_context);
        }

        public ManageVacancyPage ConfirmLiveVacancyDetailsAndClickApplications(string status)
        {
            ConfirmLiveVacancyDetails(status);
            ClickApplicationsLink();
            return new ManageVacancyPage(_context);
        }

        public ManageVacancyPage ConfirmClosedVacancyDetailsAndClickApplications(string status)
        {
            ConfirmClosedVacancyDetails(status);
            ClickApplicationsLink();
            return new ManageVacancyPage(_context);
        }

        private void ClickApplicationsLink()
        {
            List<IWebElement> links = pageInteractionHelper.FindElements(ApplicationsLink);
            foreach (var link in links)
            {
                if (link.Text.Contains("application"))
                {
                    link.Click();
                    break;
                }
            }

        }
    }
}
