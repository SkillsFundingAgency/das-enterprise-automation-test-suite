using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderEditApprenticePage : BasePage
    {
        protected override string PageTitle => "Edit apprentice";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly CocDataHelper _dataHelper;
        #endregion


        private By FirstNameField => By.Id("FirstName");
        private By LastNameField => By.Id("LastName");
        private By DateOfBirthDay => By.Id("DateOfBirth_Day");
        private By DateOfBirthMonth => By.Id("DateOfBirth_Month");
        private By DateOfBirthYear => By.Id("DateOfBirth_Year");
        private By Uln => By.Id("ULN");
        private By TrainingCourseContainer => By.Id("select2-TrainingCode-container");
        private By StandardCourseOption => By.CssSelector("#TrainingCode option[value='176']");
        private By FrameworkCourseOption => By.CssSelector("#TrainingCode option[value='454-2-1']");
        private By StartDateMonth => By.Id("StartDate_Month");
        private By StartDateYear => By.Id("StartDate_Year");
        private By EndDateMonth => By.Id("EndDate_Month");
        private By EndDateYear => By.Id("EndDate_Year");
        private By TrainingCost => By.Id("Cost");
        private By ProviderReference => By.Id("ProviderRef");
        private By UpdateDetailsButton => By.Id("submit-edit-details");

        public ProviderEditApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<CocDataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ProviderConfirmChangesPage EditTheApprenticePostApprovalAfterIlrMatchAndSubmit()
        {
            EditNameDobAndReference();
            _formCompletionHelper.ClickElement(UpdateDetailsButton);
            return new ProviderConfirmChangesPage(_context);
        }
        private void EditNameDobAndReference()
        {
            _formCompletionHelper.EnterText(FirstNameField, _dataHelper.SetCurrentApprenticeEditedFirstname());
            _formCompletionHelper.EnterText(LastNameField, _dataHelper.SetCurrentApprenticeEditedLastname());
            _formCompletionHelper.EnterText(DateOfBirthDay, _dataHelper.DateOfBirthDay);
            _formCompletionHelper.EnterText(DateOfBirthMonth, _dataHelper.DateOfBirthMonth);
            _formCompletionHelper.EnterText(DateOfBirthYear, _dataHelper.DateOfBirthYear);
            _formCompletionHelper.EnterText(ProviderReference, _dataHelper.ProviederRefernce);
        }
    }
}
