using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class RecruitmentDynamicHomePage : HomePage
    {

        #region Helpers and Context
        private readonly VacancyTitleDatahelper _vacancyTitleDataHelper;
        private readonly RAAV2DataHelper _raaV2DataHelper;
        #endregion

        private static By AddApprenticeDetails => By.LinkText("Add apprentice details");
        private static By TRows => By.CssSelector("tr");
        private static By THeader => By.CssSelector("th");
        private static By TData => By.CssSelector("td");

        public RecruitmentDynamicHomePage(ScenarioContext context, bool navigate) : base(context, navigate)
        {
            _vacancyTitleDataHelper = context.Get<VacancyTitleDatahelper>();
            _raaV2DataHelper = context.Get<RAAV2DataHelper>();
        }

        public VacancyCompletedAllSectionsPage ReviewYourVacancy()
        {
            formCompletionHelper.ClickLinkByText("Review your advert");
            return new VacancyCompletedAllSectionsPage(context);
        }

        public RecruitmentDynamicHomePage ConfirmVacancyTitleAndStatus(string status)
        {
            pageInteractionHelper.VerifyText(GetDetails("Title").Text.ToString(), _vacancyTitleDataHelper.VacancyTitle);
            pageInteractionHelper.VerifyText(GetDetails("Status").Text.ToString(), status);
            return this;
        }

        public CreateAnApprenticeshipAdvertOrVacancyPage ContinueCreatingYourAdvert()
        {
            formCompletionHelper.ClickLinkByText("Continue creating your advert");
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        public YourApprenticeshipAdvertsHomePage GoToVacancyDashboard()
        {
            formCompletionHelper.ClickLinkByText("Go to your vacancy dashboard");
            return new YourApprenticeshipAdvertsHomePage(context);
        }

        public ManageRecruitPage GoToManageVacancyPage()
        {
            formCompletionHelper.ClickLinkByText("application");
            return new ManageRecruitPage(context);
        }
        public RecruitmentDynamicHomePage ConfirmVacancyDetails(string status, DateTime dateTime)
        {
            ConfirmVacancyTitleAndStatus(status);
            return ConfirmClosedDateAndApplicationsLink(dateTime, status);
        }

        public RecruitmentDynamicHomePage ConfirmLiveVacancyDetails(string status)
        {
            ConfirmVacancyDetails(status, _raaV2DataHelper.VacancyClosing);
            return ConfirmAddApprenticeDeatilsButton();
        }

        public RecruitmentDynamicHomePage ConfirmClosedVacancyDetails(string status)
        {
            ConfirmVacancyTitleAndStatus(status);
            ConfirmClosedDateAndApplicationsLink(DateTime.Today, status);
            return ConfirmAddApprenticeDeatilsButton();
        }

        private RecruitmentDynamicHomePage ConfirmClosedDateAndApplicationsLink(DateTime closingDate, string status)
        {
            pageInteractionHelper.VerifyText(GetDetails("Closing date").Text.ToString(), closingDate.ToString("dd MMMM yyyy"), closingDate.ToString("dd MMM yyyy"));
            if (status != "PENDING REVIEW")
            {
                pageInteractionHelper.VerifyText(GetDetails("Applications").Text.ToString(), "application");
            }
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
