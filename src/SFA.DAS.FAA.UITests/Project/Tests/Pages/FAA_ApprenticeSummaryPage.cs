using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.RAA.DataGenerator.Project;
using System;
using System.Globalization;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ApprenticeSummaryPage : BasePage
    {
        protected override string PageTitle => _dataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly VacancyTitleDatahelper _dataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly RAAV1DataHelper _raaV1dataHelper;
        private readonly RegexHelper _regexHelper;
        private readonly FAADataHelper _faaDataHelper;
        #endregion

        private By ApplyButton => By.Id("apply-button");

        private By ViewApplicationLink => By.Id("view-application-link");

        private By EmployerName => By.Id("vacancy-subtitle-employer-name");

        private By EmployerNameInAboutTheEmployerSection => By.Id("vacancy-employer-name");

        private By ClosingDate => By.Id("vacancy-closing-date");

        private By StartDate => By.Id("vacancy-start-date");

        private By VacancyWage => By.Id("vacancy-wage");

        public FAA_ApprenticeSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<VacancyTitleDatahelper>();
            _raaV1dataHelper = context.Get<RAAV1DataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _regexHelper = context.Get<RegexHelper>();
            _faaDataHelper = context.Get<FAADataHelper>();
            VerifyPage();
            if (!_objectContext.IsRAAV1()) { VerifyEmployerDetails(); }
        }

        public FAA_YourApplicationPage View()
        {
            _formCompletionHelper.Click(ViewApplicationLink);
            return new FAA_YourApplicationPage(_context);
        }

        public FAA_ApplicationFormPage Apply()
        {
            _formCompletionHelper.Click(ApplyButton);
            return new FAA_ApplicationFormPage(_context);
        }

        private void VerifyEmployerDetails()
        {
            var empName = _objectContext.GetEmployerName();
            VerifyPage(EmployerName, empName);
            VerifyPage(EmployerNameInAboutTheEmployerSection, empName);
        }

        public void VerifyNewDates()
        {
            DateTime Date = _raaV1dataHelper.NewVacancyClosing;
            string actualClosingDate = Date.ToString("dd MMM yyyy");

            DateTime PossibleStartDate = _raaV1dataHelper.NewVacancyStart;
            string actualStartDate = PossibleStartDate.ToString("dd MMM yyyy");

            _pageInteractionHelper.VerifyText(ClosingDate, "Closing date: " + actualClosingDate + "");
            _pageInteractionHelper.VerifyText(StartDate,actualStartDate);
        }

        public void VerifyNewWages()
        {
            string displayedWageFAA = _pageInteractionHelper.GetText(VacancyWage);
            string[] wageRange = displayedWageFAA.Split('-');
            string minWage =_regexHelper.GetVacancyCurrentWage(wageRange[0]);
            string maxWage = _regexHelper.GetVacancyCurrentWage(wageRange[1]);
            _pageInteractionHelper.VerifyText(minWage,_faaDataHelper.NewCustomMinWagePerWeek);
            _pageInteractionHelper.VerifyText(maxWage,_faaDataHelper.NewCustomMaxWagePerWeek);
        }
    }
}
