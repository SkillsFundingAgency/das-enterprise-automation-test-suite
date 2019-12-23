using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Reviewer
{
    public class Reviewer_VacancyPreviewPage : VerifyDetailsBasePage
    {
        protected override string PageTitle => _vacancyTitleDatahelper.VacancyTitle;

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ObjectContext _objectContext;
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;
        #endregion

        private By ErrorsCheckboxs => By.Name("SelectedAutomatedQaResults");

        private By SubmitButton => By.CssSelector("#submit-button");

        protected override By EmployerName => By.ClassName("govuk-caption-xl");

        protected override By EmployerNameInAboutTheEmployerSection => By.XPath("//div[@id='EmployerName']/p");

        protected override By DisabilityConfident => By.CssSelector("img.disability-confident-logo");

        public Reviewer_VacancyPreviewPage(ScenarioContext context) : base(context)
        {
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

        public new Reviewer_VacancyPreviewPage VerifyEmployerName()
        {
            base.VerifyEmployerName();
            return this;
        }

        public new Reviewer_VacancyPreviewPage VerifyDisabilityConfident()
        {
            base.VerifyDisabilityConfident();
            return this;
        }
    }
}
