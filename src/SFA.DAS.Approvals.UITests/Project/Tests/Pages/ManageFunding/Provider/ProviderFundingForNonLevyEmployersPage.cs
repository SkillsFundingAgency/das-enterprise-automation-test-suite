using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderFundingForNonLevyEmployersPage : FundingBasePage
    {
        protected override string PageTitle => "Funding for non-levy employers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderFundingForNonLevyEmployersPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        internal ProviderAddApprenticeDetailsPage AddApprenticeWithReservedFunding()
        {
            formCompletionHelper.ClickElement(AddApprenticeLink);
            return new ProviderAddApprenticeDetailsPage(_context);
        }
    }
}
