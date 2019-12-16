using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Reviewer
{
    public class Reviewer_VacancyPreviewPage : BasePage
    {
        protected override string PageTitle => _vacancyTitleDatahelper.VacancyTitle;

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;
        #endregion

        private By ErrorsCheckboxs => By.Name("SelectedAutomatedQaResults");

        private By SubmitButton => By.CssSelector("#submit-button");

        private By EmployerName => By.ClassName("govuk-caption-xl");

        private By EmployerNameInAboutTheEmployerSection => By.XPath("//div[@id='EmployerName']/p");

        private By EmployerLocation => By.CssSelector(".govuk-grid-column-one-half .govuk-list");
        public Reviewer_VacancyPreviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _vacancyTitleDatahelper = context.Get<VacancyTitleDatahelper>();
            VerifyPage();
        }

        public void Approve()
        {
            var errors = _pageInteractionHelper.FindElements(ErrorsCheckboxs);

            foreach (var error in errors)
            {
                _formCompletionHelper.UnSelectCheckbox(error);
            }

            _formCompletionHelper.Click(SubmitButton);
        }

        public Reviewer_VacancyPreviewPage VerifyEmployerDetails()
        {
            var empName = _objectContext.GetEmployerName();
            VerifyPage(EmployerName, empName);
            VerifyPage(EmployerNameInAboutTheEmployerSection, empName);
            VerifyPage(EmployerLocation, _objectContext.GetEmployerLocation());
            return this;
        }
    }
}
