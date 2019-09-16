using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectcontext;
        private ApprenticeDataHelper _datahelper;
        private readonly ApprovalsConfig _approvalsConfig;
        private readonly SqlDatabaseConnectionHelper _sqlDatabaseConnectionHelper;

        public BeforeScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _objectcontext = context.Get<ObjectContext>();
            _approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
            _sqlDatabaseConnectionHelper = context.Get<SqlDatabaseConnectionHelper>();
        }

        [BeforeScenario(Order = 22)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            var apprenticeStatus = _context.ScenarioInfo.Tags.Contains("liveapprentice") ? ApprenticeStatus.Live :
                                   _context.ScenarioInfo.Tags.Contains("waitingtostartapprentice") ? ApprenticeStatus.WaitingToStart : ApprenticeStatus.Random;

            var commitmentsdatahelper = new CommitmentsDataHelper(_approvalsConfig, _sqlDatabaseConnectionHelper);

            _context.Set(commitmentsdatahelper);

            _datahelper = new ApprenticeDataHelper(_objectcontext, random, commitmentsdatahelper);

            _context.Set(_datahelper);

            _context.Set(new EditedApprenticeDataHelper(random, _datahelper));

            var apprenticeCourseDataHelper = new ApprenticeCourseDataHelper(random, apprenticeStatus);

            _context.Set(apprenticeCourseDataHelper);

            _context.Set(new EditedApprenticeCourseDataHelper(random, apprenticeCourseDataHelper));

            _context.Set(new TabHelper(_context.GetWebDriver()));

            _context.Set(new DlockDataHelper(_approvalsConfig, new FileHelper(), _datahelper, apprenticeCourseDataHelper, _sqlDatabaseConnectionHelper));
        }
    }
}
