using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => "Edit apprentice details";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        private By FirstNameField => By.Id("FirstName");
        private By LastNameField => By.Id("LastName");
        private By DateOfBirthDay => By.Id("BirthDay");
        private By DateOfBirthMonth => By.Id("BirthMonth");
        private By DateOfBirthYear => By.Id("BirthYear");
        private By Uln => By.Id("Uln");
        private By TrainingCourseContainer => By.Id("CourseCode");
        private By StartDateMonth => By.Id("StartMonth");
        private By StartDateYear => By.Id("StartYear");
        private By EndDateMonth => By.Id("EndMonth");
        private By EndDateYear => By.Id("EndYear");
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("Reference");
        private By SaveButton => By.CssSelector(".govuk-button");
        private By DeleteButton => By.LinkText("Delete");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeDataHelper _datahelper;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ApprenticeCourseDataHelper _coursedataHelper;
        private readonly LoginCredentialsHelper _loginCredentialsHelper;
        #endregion

        public ProviderEditApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _datahelper = context.Get<ApprenticeDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tableRowHelper = context.Get<TableRowHelper>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _coursedataHelper = context.Get<ApprenticeCourseDataHelper>();
            _loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            VerifyPage();
        }

        public ProviderReviewYourCohortPage EnterUlnAndSave()
        {
            _formCompletionHelper.EnterText(Uln, _datahelper.Uln());
            _formCompletionHelper.ClickElement(SaveButton);
            return new ProviderReviewYourCohortPage(_context);
        }

        public ProviderReviewYourCohortPage EditAllApprenticeDetails()
        {
            _formCompletionHelper.EnterText(FirstNameField, _dataHelper.ApprenticeFirstname);
            _formCompletionHelper.EnterText(LastNameField, _dataHelper.ApprenticeLastname);
            _formCompletionHelper.EnterText(DateOfBirthDay, _dataHelper.DateOfBirthDay);
            _formCompletionHelper.EnterText(DateOfBirthMonth, _dataHelper.DateOfBirthMonth);
            _formCompletionHelper.EnterText(DateOfBirthYear, _dataHelper.DateOfBirthYear);
            _formCompletionHelper.EnterText(Uln, _dataHelper.Uln());
            _formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, _coursedataHelper.Course);
            _formCompletionHelper.ClickElement(StartDateMonth);
            _formCompletionHelper.EnterText(StartDateMonth, _coursedataHelper.CourseStartDate.Month);
            _formCompletionHelper.EnterText(StartDateYear, _coursedataHelper.CourseStartDate.Year);
            if (_loginCredentialsHelper.IsLevy == false)
            {
                DateTime now = DateTime.Now;
                _formCompletionHelper.EnterText(StartDateMonth, now.Month);
                _formCompletionHelper.EnterText(StartDateYear, now.Year);
            }
            _formCompletionHelper.EnterText(EndDateMonth, _coursedataHelper.CourseEndDate.Month);
            _formCompletionHelper.EnterText(EndDateYear, _coursedataHelper.CourseEndDate.Year);
            _formCompletionHelper.EnterText(TrainingCost, _dataHelper.TrainingPrice);
            _formCompletionHelper.EnterText(EmployerReference, _dataHelper.EmployerReference);

            _formCompletionHelper.ClickElement(SaveButton);
            return new ProviderReviewYourCohortPage(_context);
        }

        public ProviderConfirmApprenticeDeletionPage DeleteApprentice()
        {
            _formCompletionHelper.ClickElement(DeleteButton);
            return new ProviderConfirmApprenticeDeletionPage(_context);
        }
    }
}
