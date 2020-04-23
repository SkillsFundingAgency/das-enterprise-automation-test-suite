using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsApprovedAndSentToTrainingProviderPage : CohortReferenceBasePage
    {
        protected override string PageTitle => "Apprentice details approved and sent to training provider";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");
                
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion
        
        public ApprenticeDetailsApprovedAndSentToTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
       
    }
}