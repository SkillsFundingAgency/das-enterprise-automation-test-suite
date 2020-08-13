using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprovalsEISteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerSteps _employerSteps;
        private readonly ProviderSteps _providerSteps;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;

        public ApprovalsEISteps(ScenarioContext context)
        {
            _context = context;
            _employerSteps = new EmployerSteps(_context);
            _providerSteps = new ProviderSteps(_context);
            _objectContext = context.Get<ObjectContext>();
            _tabHelper = context.Get<TabHelper>();
        }

        [Given(@"the Employer adds (.*) apprentices (Aged16to24|AgedAbove25) as of 01AUG2020 with start date as Month (.*) and Year (.*)")]
        public void GivenTheEmployerAddsApprenticesOfSpecifiedAgeCategorywithStartDateAsMentioned(int numberOfApprentices, string eIAgeCategoryAsOfAug2020, int eIStartmonth, int eIStartyear)
        {
            _objectContext.SetIsEIJourney(true);
            _objectContext.SetEIAgeCategoryAsOfAug2020(eIAgeCategoryAsOfAug2020);
            _objectContext.SetEIStartMonth(eIStartmonth);
            _objectContext.SetEIStartYear(eIStartyear);

            _employerSteps.TheEmployerApprovesCohortAndSendsToProvider(numberOfApprentices);
            _providerSteps.TheProviderAddsUlnsAndApprovesTheCohorts();
            new HomePage(_context, true);

            _tabHelper.SwitchToFirstTab();
        }
    }
}
