using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_AdministratorFunctionsPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Administrator functions";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RAA_AdministratorFunctionsPage(ScenarioContext context): base(context)
        {
            _context = context;
        }

        public RAA_ProviderUsersPage ProviderUsers()
        {
            formCompletionHelper.ClickLinkByText("Provider Users");
            return new RAA_ProviderUsersPage(_context);
        }

        public RAA_ChangeUkprnPage ChangeUkprn()
        {
            formCompletionHelper.ClickLinkByText("Change UKPRN");
            return new RAA_ChangeUkprnPage(_context);
        }

        public RAA_ResetUkprnPage ResetUkprn()
        {
            formCompletionHelper.ClickLinkByText("Reset UKPRN");
            return new RAA_ResetUkprnPage(_context);
        }

        public RAA_TransferVacanciesPage TransferVacancies()
        {
            formCompletionHelper.ClickLinkByText("Transfer Vacancies");
            return new RAA_TransferVacanciesPage(_context);
        }

        public RAA_SetVacancyHoursAndWageTypePage SetVacancyHoursAndWageType()
        {
            formCompletionHelper.ClickLinkByText("Set Vacancy Hours and Wage Type");
            return new RAA_SetVacancyHoursAndWageTypePage(_context);
        }
    }

    public class RAA_ProviderUsersPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Provider Users";

        public RAA_ProviderUsersPage(ScenarioContext context) : base(context)
        {

        }
    }

    public class RAA_ChangeUkprnPage: RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Change UKPRN";

        public RAA_ChangeUkprnPage(ScenarioContext context) : base(context)
        {

        }
    }
    public class RAA_ResetUkprnPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Your UKPRN has been reset";

        protected override By PageHeader => By.CssSelector("#SuccessMessageText");

        public RAA_ResetUkprnPage(ScenarioContext context) : base(context)
        {

        }
    }
    public class RAA_TransferVacanciesPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Transfer Vacancies";

        public RAA_TransferVacanciesPage(ScenarioContext context) : base(context)
        {

        }
    }
    public class RAA_SetVacancyHoursAndWageTypePage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Set Vacancy Hours and Wage";

        public RAA_SetVacancyHoursAndWageTypePage(ScenarioContext context) : base(context)
        {

        }
    }
}