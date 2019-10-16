using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ManageFunding
{
    public class ProviderApprenticeshipTrainingPage : BasePage
    {
        protected override string PageTitle => "Apprenticeship training";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By CourseSearch => By.CssSelector("#course-search, #SelectedCourseId");
        private By Options => By.CssSelector(".govuk-radios");
        private By SaveAndContinueButton => By.CssSelector(".govuk-button");

        public ProviderApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        internal ProviderCheckYourInformationPage AddTrainingCourseAndDate()
        {
            _formCompletionHelper.EnterText(CourseSearch, "Software Developer - Level 4");

            var option = _pageInteractionHelper.FindElements(Options);

            _formCompletionHelper.ClickElement(option.LastOrDefault());

            _formCompletionHelper.ClickElement(SaveAndContinueButton);

            return new ProviderCheckYourInformationPage(_context);
        }
    }
}
