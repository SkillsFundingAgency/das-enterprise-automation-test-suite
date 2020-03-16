using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
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

        private By AdvertPanel => By.ClassName("dashboard-section");

        private By VacancyDetails => By.ClassName("responsive");
        private By ContinueCreatingNewVacancy => By.LinkText("Continue creating your vacancy");
        private By GotoYourVacancyDashboard => By.LinkText("Go to your vacancy dashboard");
        private By ReviewYourVacancy => By.LinkText("Review your vacancy");
        private By ApplicationsLink => By.CssSelector(".govuk-link");
        private By AddApprenticeDetails => By.LinkText("Add apprentice details");
        private By LiveStatus => By.CssSelector(".govuk-tag govuk-tag--active");
        private By TRows => By.CssSelector("tr");
        private By THeader => By.CssSelector("th");
        private By TData => By.CssSelector("td");


        public DynamicHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            _raaV2DataHelper = context.Get<RAAV2DataHelper>();
        }

        private IWebElement GetStatus(string headerName)
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

        private IWebElement GetTitle(string title)
        {
            foreach (var row in pageInteractionHelper.FindElements(TRows))
            {
                if (row.FindElement(THeader).Text.ContainsCompareCaseInsensitive(title))
                {
                    return row.FindElement(TData);
                }
            }
            throw new NotFoundException($"{title} not found");
        }

        private IWebElement GetClosingDate(string closingDate)
        {
            foreach (var row in pageInteractionHelper.FindElements(TRows))
            {
                if (row.FindElement(THeader).Text.ContainsCompareCaseInsensitive(closingDate))
                {
                    return row.FindElement(TData);
                }
            }
            throw new NotFoundException($"{closingDate} not found");
        }

        private IWebElement GetApplications(string applications)
        {
            foreach (var row in pageInteractionHelper.FindElements(TRows))
            {
                if (row.FindElement(THeader).Text.ContainsCompareCaseInsensitive(applications))
                {
                    return row.FindElement(TData);
                }
            }
            throw new NotFoundException($"{applications} not found");
        }

        public void ConfirmVacancyTitleAndStatus(string status)
        {
            string vacancyStatus = GetStatus("Status").Text.ToString();
            pageInteractionHelper.VerifyText(GetTitle("Title").Text.ToString(), _vacancyTitleDataHelper.VacancyTitle);
            pageInteractionHelper.VerifyText(vacancyStatus, status);
        }

        public void ConfirmSubmittedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            VerifyClosingDate(_raaV2DataHelper.VacancyClosing.ToString("dd MMM yyyy"));
            VerifyApplicationLink();
        }

        public void ConfirmRejectedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
        }

        public void ConfirmLiveVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            VerifyClosingDate(_raaV2DataHelper.VacancyClosing.ToString("dd MMM yyyy"));
            VerifyApplicationLink();
        }

        public void ConfirmClosedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            VerifyClosingDate(DateTime.Today.ToString("dd MMMM yyyy"));
            VerifyApplicationLink();
        }

        private void VerifyClosingDate(string closingDate)
        {
            pageInteractionHelper.VerifyText(GetClosingDate("Closing date").Text.ToString(), closingDate);
        }

        private void VerifyApplicationLink()
        {
            pageInteractionHelper.VerifyText(GetApplications("Applications").Text.ToString(), "application");
        }

        public void ClicktheButtonOnAdvertPage(string button)
        {

            List<IWebElement> links = pageInteractionHelper.FindElements(ApplicationsLink);
            switch (button)
            {
                case "Continue creating your vacancy":
                    formCompletionHelper.Click(ContinueCreatingNewVacancy);
                    break;
                case "Go to your vacancy dashboard":
                    formCompletionHelper.Click(GotoYourVacancyDashboard);
                    break;

                case "Review your vacancy":
                    formCompletionHelper.Click(ReviewYourVacancy);
                    break;

                case "application":
                    foreach (var link in links)
                    {
                        if (link.Text.Contains("application"))
                        {
                            link.Click();
                            break;
                        }
                    }
                    break;
            }
        }
    }
}
