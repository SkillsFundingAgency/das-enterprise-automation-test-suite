using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ApplicationPreviewPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => dataHelper.VacancyTitle;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Notes => By.CssSelector("#Notes");

        private By RadioOptions => By.CssSelector("label.selection-button-radio");

        public RAA_ApplicationPreviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_VacancySummaryPage ChangeStatus(string newstatus)
        {
            formCompletionHelper.EnterText(Notes, dataHelper.OptionalMessage);

            string forAttribute = string.Empty;
            switch (true)
            {
                case bool _ when newstatus == "New":
                    forAttribute = "application-status-submitted";
                    break;
                case bool _ when newstatus == "In progress":
                    forAttribute = "application-status-inprogress";
                    break;
                case bool _ when newstatus == "Unsuccessful":
                    forAttribute = "application-status-unsuccessful";
                    break;
                case bool _ when newstatus == "Successful":
                    forAttribute = "application-status-successful";
                    break;
                default:
                    break;
            }

            formCompletionHelper.SelectRadioOptionByForAttribute(RadioOptions, forAttribute);

            return new RAA_VacancySummaryPage(_context);
        }

    }
}
