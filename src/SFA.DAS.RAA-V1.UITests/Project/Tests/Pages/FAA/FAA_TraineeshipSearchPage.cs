using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_TraineeshipSearchPage : BasePage
    {
        protected override string PageTitle => "Find a traineeship";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        
        private By Location => By.Id("Location");

        private By ReferenceNumber => By.Id("ReferenceNumber");

        private By Search => By.Id("search-button");

        public FAA_TraineeshipSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public FAA_ApprenticeSummaryPage SearchByReferenceNumber()
        {
            _formCompletionHelper.EnterText(Location, string.Empty);
            _formCompletionHelper.EnterText(ReferenceNumber, _objectContext.GetVacancyReference());
            _formCompletionHelper.Click(Search);
            return new FAA_ApprenticeSummaryPage(_context);
        }

    }
}
