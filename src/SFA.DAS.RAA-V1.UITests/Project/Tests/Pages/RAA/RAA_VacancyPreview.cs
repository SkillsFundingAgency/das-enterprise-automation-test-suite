using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{

    public class RAA_VacancyReferencePage : BasePage
    {
        protected override string PageTitle => "";
        
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        private By VacancyReferenceNumber => By.XPath("//strong[@class='heading-medium']");

        private By SignOut => By.Id("signout-link");

        public RAA_VacancyReferencePage(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage(VacancyReferenceNumber);
        }

        public string GetVacancyReference()
        {
            var referenceNumber = _pageInteractionHelper.GetText(VacancyReferenceNumber);
            return referenceNumber.Remove(0, 3);
        }

        public void ExitFromWebsite()
        {
            _formCompletionHelper.Click(SignOut);
        }

    }

    public class RAA_VacancyPreview : BasePage
    {
        protected override string PageTitle => "Vacancy preview";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By SubmitForApprovalButton => By.CssSelector("#submit-vacancy-form > section > button");
        private By CloseVacancyLink => By.LinkText("Close this vacancy");
        private By ChangeVacancyDates => By.LinkText("Change vacancy dates");

        public RAA_VacancyPreview(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public RAA_VacancyReferencePage ClickSubmitForApprovalButton()
        {
            _formCompletionHelper.Click(SubmitForApprovalButton);
            return new RAA_VacancyReferencePage(_context);
        }

        public RAA_VacancyPreview ClickCloseVacancyLink()
        {
            _formCompletionHelper.Click(CloseVacancyLink);
            return this;
        }

        public RAA_VacancyPreview ClickChangeVacancyDates()
        {
            _formCompletionHelper.Click(ChangeVacancyDates);
            return this;
        }

        public RAA_VacancyPreview ClickIncreaseWage()
        {
            _formCompletionHelper.Click(ChangeVacancyDates);
            return this;
        }
    }
}
