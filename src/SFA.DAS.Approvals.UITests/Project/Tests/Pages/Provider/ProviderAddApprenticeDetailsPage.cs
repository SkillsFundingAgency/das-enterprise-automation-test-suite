using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderAddApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => "Add apprentice details";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprovalsConfig _config;
        private readonly ApprovalsDataHelper _dataHelper;
        private readonly LoginCredentialsHelper _loginCredentialsHelper;
        #endregion


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
        private By AddButton => By.CssSelector(".govuk-button");

        public ProviderAddApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<ApprovalsDataHelper>();
            _loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            VerifyPage();
        }

        internal ProviderReviewYourCohortPage SubmitValidApprenticeDetails()
        {
            _formCompletionHelper.EnterText(FirstNameField, _dataHelper.ApprenticeFirstname);
            _formCompletionHelper.EnterText(LastNameField, _dataHelper.ApprenticeLastname);
            _formCompletionHelper.EnterText(DateOfBirthDay, _dataHelper.DateOfBirthDay);
            _formCompletionHelper.EnterText(DateOfBirthMonth, _dataHelper.DateOfBirthMonth);
            _formCompletionHelper.EnterText(DateOfBirthYear, _dataHelper.DateOfBirthYear);
            _formCompletionHelper.EnterText(Uln, _dataHelper.Uln());
            _formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, _dataHelper.RandomCourse());
            _formCompletionHelper.ClickElement(StartDateMonth);
            _formCompletionHelper.EnterText(StartDateMonth, _dataHelper.CourseStartDate.Month);
            _formCompletionHelper.EnterText(StartDateYear, _dataHelper.CourseStartDate.Year);
            if (_loginCredentialsHelper.IsLevy == false)
            {
                DateTime now = DateTime.Now;
                _formCompletionHelper.EnterText(StartDateMonth, now.Month);
                _formCompletionHelper.EnterText(StartDateYear, now.Year);
            }
            _formCompletionHelper.EnterText(EndDateMonth, _dataHelper.CourseEndDate.Month);
            _formCompletionHelper.EnterText(EndDateYear, _dataHelper.CourseEndDate.Year);
            _formCompletionHelper.EnterText(TrainingCost, _dataHelper.TrainingPrice);
            _formCompletionHelper.EnterText(EmployerReference, _dataHelper.EmployerReference);
            _formCompletionHelper.ClickElement(AddButton);
            return new ProviderReviewYourCohortPage(_context);
        }

    }
}