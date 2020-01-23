using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class End2EndSteps
    {
        private readonly ScenarioContext _context;
        private readonly End2EndStepsHelper _end2EndStepsHelper;
        private ApplicationOverviewPage _overviewPage;
        private EnterUkprnPage _enterUkprnPage;

        public End2EndSteps(ScenarioContext context)
        {
            _context = context;
            _end2EndStepsHelper = new End2EndStepsHelper(_context);
        }

        [Given(@"the provider initates an application as main route company")]
        public void GivenTheProviderInitatesAnApplicationAsMainRouteCompany()
        {
            var termsConditionsMakingApplicationPage = _end2EndStepsHelper.SubmitValidUserDetails();

            _enterUkprnPage = _end2EndStepsHelper.AcceptAndContinue(termsConditionsMakingApplicationPage);

            _overviewPage =  _end2EndStepsHelper.CompleteProviderRouteSection(_enterUkprnPage);

            _overviewPage = _end2EndStepsHelper.CompleteYourOrganisationSection(_overviewPage);
        }
    }
}
