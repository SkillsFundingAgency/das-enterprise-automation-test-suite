using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => "Add apprentice details";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        private readonly ApprovalsDataHelper _dataHelper;
        #endregion

        private By FirstNameField => By.Id("FirstName");
        private By LastNameField => By.Id("LastName");
        private By DateOfBirthDay => By.Id("BirthDay");
        private By DateOfBirthMonth => By.Id("BirthMonth");
        private By DateOfBirthYear => By.Id("BirthYear");
        private By TrainingCourseContainer => By.Id("CourseCode");
        private By StartDateMonth => By.Id("StartMonth");
        private By StartDateYear => By.Id("StartYear");
        private By EndDateMonth => By.Id("EndMonth");
        private By EndDateYear => By.Id("EndYear");
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("Reference");
        private By SaveAndContinueButton => By.CssSelector(".govuk-button");

        public AddApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _dataHelper = context.Get<ApprovalsDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ReviewYourCohortPage SubmitValidApprenticeDetails()
        {
            _formCompletionHelper.EnterText(FirstNameField, _dataHelper.ApprenticeFirstname);
            _formCompletionHelper.EnterText(LastNameField, _dataHelper.ApprenticeLastname);
            _formCompletionHelper.EnterText(DateOfBirthDay, _dataHelper.DateOfBirthDay);
            _formCompletionHelper.EnterText(DateOfBirthMonth, _dataHelper.DateOfBirthMonth);
            _formCompletionHelper.EnterText(DateOfBirthYear, _dataHelper.DateOfBirthYear);
            _formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, _dataHelper.RandomCourse());
            _formCompletionHelper.ClickElement(StartDateMonth);
            _formCompletionHelper.EnterText(StartDateMonth, _dataHelper.CourseStartDate.Month);
            _formCompletionHelper.EnterText(StartDateYear, _dataHelper.CourseStartDate.Year);
            _formCompletionHelper.EnterText(EndDateMonth, _dataHelper.CourseEndDate.Month);
            _formCompletionHelper.EnterText(EndDateYear, _dataHelper.CourseEndDate.Year);
            _formCompletionHelper.EnterText(TrainingCost, _dataHelper.TrainingPrice);
            _formCompletionHelper.EnterText(EmployerReference, _dataHelper.EmployerReference);
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ReviewYourCohortPage(_context);
        }
    }
}