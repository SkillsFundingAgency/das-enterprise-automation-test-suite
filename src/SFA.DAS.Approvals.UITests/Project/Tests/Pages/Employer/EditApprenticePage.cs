using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditApprenticePage : EditApprentice
    {
        protected override string PageTitle => "Edit apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EditedApprenticeCourseDataHelper _coursedataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ApprenticeDataHelper _dataHelper;
        #endregion

        private By CourseOption => By.CssSelector("#TrainingCode");
        private By VerifyEditApprenticeDetailsPage = By.CssSelector("#main-content > div > div > h1");

        private By DeleteButton => By.LinkText("Delete");

        public EditApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _coursedataHelper = context.Get<EditedApprenticeCourseDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            
        }

        public ConfirmApprenticeDeletionPage SelectDeleteApprentice()
        {
           formCompletionHelper.ClickElement(DeleteButton);
            return new ConfirmApprenticeDeletionPage(_context);
        }

        public ConfirmChangesPage EditCostCourseAndReference()
        {
            EditCostCourseAndReference(dataHelper.EmployerReference);
            return ConfirmChangesPage();
        }

        public ConfirmChangesPage EditApprenticeNameDobAndReference()
        {
            EditApprenticeNameDobAndReference(dataHelper.EmployerReference);
            return ConfirmChangesPage();
        }
        protected override void SelectCourse()
        {
            formCompletionHelper.SelectFromDropDownByValue(CourseOption, _coursedataHelper.EditedCourse);
        }

        private ConfirmChangesPage ConfirmChangesPage()
        {
            return new ConfirmChangesPage(_context);
        }
        public AddApprenticeDetailsPage VerifyEditApprenticePage()
        {
            _pageInteractionHelper.VerifyPage(VerifyEditApprenticeDetailsPage);
            //_pageInteractionHelper.VerifyText(VerifyEditApprenticeDetailsPage, PageTitle);
            return new AddApprenticeDetailsPage(_context);
        }
        /*public ApproveApprenticeDetailsPage SaveEditApprenticePage()
        {
          AddApprenticeDetailsPage _addApprenticeDetailsPage = new AddApprenticeDetailsPage(_context);
          _addApprenticeDetailsPage.ContinueToAddValidApprenticeDetails();
            return new ApproveApprenticeDetailsPage(_context);
        }*/
    }
}