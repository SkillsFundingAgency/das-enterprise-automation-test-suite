using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class RecruitmentDynamicHomePage : HomePage
    {

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly VacancyTitleDatahelper _vacancyTitleDataHelper;
        private readonly RAAV2DataHelper _raaV2DataHelper;
        #endregion
       
        private By AddApprenticeDetails => By.LinkText("Add apprentice details");
        private By TRows => By.CssSelector("tr");
        private By THeader => By.CssSelector("th");
        private By TData => By.CssSelector("td");


        public RecruitmentDynamicHomePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _context = context;
            _vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            _raaV2DataHelper = context.Get<RAAV2DataHelper>();
        }

        public VacancyPreviewPart2Page ReviewYourVacancy()
        {
            formCompletionHelper.ClickLinkByText("Review your vacancy");
            return new VacancyPreviewPart2Page(_context);
        }

        public RecruitmentDynamicHomePage ConfirmVacancyTitleAndStatus(string status)
        {
            pageInteractionHelper.VerifyText(GetDetails("Title").Text.ToString(), _vacancyTitleDataHelper.VacancyTitle);
            pageInteractionHelper.VerifyText(GetDetails("Status").Text.ToString(), status);
            return this;
        }

        public RecruitmentDynamicHomePage ConfirmVacancyDetails(string status, DateTime dateTime)
        {
            ConfirmVacancyTitleAndStatus(status);
            return ConfirmClosedDateAndApplicationsLink(dateTime.ToString("dd MMM yyyy"));
        }

        public RecruitmentDynamicHomePage ConfirmLiveVacancyDetails(string status)
        {
            ConfirmVacancyDetails(status, _raaV2DataHelper.VacancyClosing);
            return ConfirmAddApprenticeDeatilsButton();
        }

        public RecruitmentDynamicHomePage ConfirmClosedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            ConfirmClosedDateAndApplicationsLink(DateTime.Today.ToString("dd MMMM yyyy"));
            return ConfirmAddApprenticeDeatilsButton();
        }

        private RecruitmentDynamicHomePage ConfirmClosedDateAndApplicationsLink(string closingDate)
        {
            pageInteractionHelper.VerifyText(GetDetails("Closing date").Text.ToString(), closingDate);
            pageInteractionHelper.VerifyText(GetDetails("Applications").Text.ToString(), "application");
            return this;
        }

        private RecruitmentDynamicHomePage ConfirmAddApprenticeDeatilsButton()
        {
            pageInteractionHelper.VerifyPage(AddApprenticeDetails);
            return this;
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
    }
}
