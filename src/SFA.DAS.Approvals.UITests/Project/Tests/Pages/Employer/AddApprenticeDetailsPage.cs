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
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ApprenticeCourseDataHelper _coursedataHelper;
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
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _coursedataHelper = context.Get<ApprenticeCourseDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public ReviewYourCohortPage SubmitValidApprenticeDetails(bool isMF)
        {
            _formCompletionHelper.EnterText(FirstNameField, _dataHelper.ApprenticeFirstname);
            _formCompletionHelper.EnterText(LastNameField, _dataHelper.ApprenticeLastname);
            _formCompletionHelper.EnterText(DateOfBirthDay, _dataHelper.DateOfBirthDay);
            _formCompletionHelper.EnterText(DateOfBirthMonth, _dataHelper.DateOfBirthMonth);
            _formCompletionHelper.EnterText(DateOfBirthYear, _dataHelper.DateOfBirthYear);
            _formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, _coursedataHelper.Course);
            _formCompletionHelper.ClickElement(StartDateMonth);
            if(isMF==false)
            {
                _formCompletionHelper.EnterText(StartDateMonth, _coursedataHelper.CourseStartDate.Month);
                _formCompletionHelper.EnterText(StartDateYear, _coursedataHelper.CourseStartDate.Year);
            }
            _formCompletionHelper.EnterText(EndDateMonth, _coursedataHelper.CourseEndDate.Month);
            _formCompletionHelper.EnterText(EndDateYear, _coursedataHelper.CourseEndDate.Year);
            _formCompletionHelper.EnterText(TrainingCost, _dataHelper.TrainingPrice);
            _formCompletionHelper.EnterText(EmployerReference, _dataHelper.EmployerReference);
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ReviewYourCohortPage(_context);
        }
        public YouMustCompleteAllApprenticeDetailsPage DraftDynamicHomePageSubmitValidApprenticeDetails()
        {
            _formCompletionHelper.EnterText(FirstNameField, _dataHelper.ApprenticeFirstname);
            _formCompletionHelper.EnterText(LastNameField, _dataHelper.ApprenticeLastname);
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new YouMustCompleteAllApprenticeDetailsPage(_context);
        }       
    }
}