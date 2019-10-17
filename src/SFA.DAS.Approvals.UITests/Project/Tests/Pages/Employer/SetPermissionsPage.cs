using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SetPermissionsPage : BasePage
    {
        protected override string PageTitle => "Set permissions";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprovalsConfig _config;
        #endregion

        private By SetCreateCohortPermissionsOptions => By.CssSelector(".govuk-radios__label");
        private By SetPermissionsButton => By.CssSelector(".govuk-button");

        public SetPermissionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetApprovalsConfig<ApprovalsConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ConfirmTrainingProviderPermissionsPage SetCreateCohortPermissions()
        {
            return CreateCohortPermissions(true)
                   .Update();
        }

        internal ConfirmTrainingProviderPermissionsPage UnSetCreateCohortPermissions()
        {
            return CreateCohortPermissions(false)
                   .Update();
        }

        internal ConfirmTrainingProviderPermissionsPage SetCreateCohortAndRecruitmentPermissions()
        {
            return CreateCohortPermissions(true)
                   .CreateRecruitmentPermissions(true)
                   .Update();
        }

        internal ConfirmTrainingProviderPermissionsPage UnSetCreateCohortAndRecruitmentPermissions()
        {
            return CreateCohortPermissions(false)
                   .CreateRecruitmentPermissions(false)
                   .Update();
        }
        internal ConfirmTrainingProviderPermissionsPage SetRecruitmentPermissions()
        {
            return CreateRecruitmentPermissions(true)
                   .Update();
        }

        internal ConfirmTrainingProviderPermissionsPage UnSetRecruitmentPermissions()
        {
            return CreateRecruitmentPermissions(false)
                   .Update();
        }

        private SetPermissionsPage CreateCohortPermissions(bool set)
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(SetCreateCohortPermissionsOptions, set ? "operation-0-yes": "operation-0-no");
            return this;
        }
        private SetPermissionsPage CreateRecruitmentPermissions(bool set)
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(SetCreateCohortPermissionsOptions, set ? "operation-1-yes" : "operation-1-no");
            return this;
        }

        private ConfirmTrainingProviderPermissionsPage Update()
        {
            _formCompletionHelper.ClickElement(SetPermissionsButton);
            return new ConfirmTrainingProviderPermissionsPage(_context);
        }
    }
}

