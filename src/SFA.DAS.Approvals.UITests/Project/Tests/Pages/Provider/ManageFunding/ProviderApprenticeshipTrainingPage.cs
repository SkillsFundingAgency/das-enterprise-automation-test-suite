using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ManageFunding
{
    public class ProviderApprenticeshipTrainingPage : BasePage
    {
        protected override string PageTitle => "Apprenticeship training";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By CourseSearch => By.Id("course-search");
        private By StandardCourseOption => By.Id("course-search__option--0");
        private By ApprenticeshipTrainingStartDate => By.Name("StartDate");
        private By SaveAndContinueButton => By.CssSelector(".govuk-button");

        public ProviderApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }


        internal ProviderCheckYourInformationPage AddTrainingCourseAndDate()
        {
            _formCompletionHelper.EnterText(CourseSearch, "Food technologist - Level 3");
            _formCompletionHelper.ClickElement(StandardCourseOption);
            _formCompletionHelper.ClickElement(ApprenticeshipTrainingStartDate);
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderCheckYourInformationPage(_context);
        }
    }
}
