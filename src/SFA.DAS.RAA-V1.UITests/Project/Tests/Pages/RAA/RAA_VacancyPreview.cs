using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancyPreview : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Vacancy preview";

        #region Helpers and Context

        private readonly ScenarioContext _context;
        #endregion

        private By SubmitForApprovalButton => By.CssSelector("#submit-vacancy-form > section > button");
        private By CloseVacancyLink => By.LinkText("Close this vacancy");
        private By ChangeVacancyDates => By.LinkText("Change vacancy dates");

        public RAA_VacancyPreview(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_VacancyReferencePage ClickSubmitForApprovalButton()
        {
            formCompletionHelper.Click(SubmitForApprovalButton);
            return new RAA_VacancyReferencePage(_context);
        }

        public RAA_VacancyPreview ClickCloseVacancyLink()
        {
            formCompletionHelper.Click(CloseVacancyLink);
            return this;
        }

        public RAA_VacancyPreview ClickChangeVacancyDates()
        {
            formCompletionHelper.Click(ChangeVacancyDates);
            return this;
        }

        public RAA_VacancyPreview ClickIncreaseWage()
        {
            formCompletionHelper.Click(ChangeVacancyDates);
            return this;
        }
    }
}
