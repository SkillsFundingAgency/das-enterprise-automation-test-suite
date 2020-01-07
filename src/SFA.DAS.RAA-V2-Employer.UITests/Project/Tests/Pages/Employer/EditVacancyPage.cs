using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class EditVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "You can edit the following information:";

        protected override By PageHeader => By.CssSelector(".govuk-heading-m");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By EditClosingDate => By.CssSelector("a[data-automation='edit-closing-date']");

        private By EditStartDate => By.CssSelector("a[data-automation='edit-start-date']");

        private By Publish => By.CssSelector(".govuk-button.save-button");

        public EditVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public EditVacancyDatesPage EditVacancyCloseDate()
        {
            formCompletionHelper.Click(EditClosingDate);
            return new EditVacancyDatesPage(_context);
        }

        public EditVacancyDatesPage EditVacancyStartDate()
        {
            formCompletionHelper.Click(EditStartDate);
            return new EditVacancyDatesPage(_context);
        }

        public EditVacancyConfirmationPage PublishVacancy()
        {
            formCompletionHelper.Click(Publish);
            return new EditVacancyConfirmationPage(_context);
        }
    }
}
