using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RegistrationEISteps
    {
        private readonly ScenarioContext _context;
        private readonly AddOrRemoveOrgSteps _addOrRemoveOrgSteps;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;

        public RegistrationEISteps(ScenarioContext context)
        {
            _context = context;
            _addOrRemoveOrgSteps = new AddOrRemoveOrgSteps(_context);
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
        }

        [Given(@"the Employer adds another legal entity")]
        public void GivenTheEmployerAddsAnotherLegalEntity()
        {
            _addOrRemoveOrgSteps.WhenTheEmployerInitiatesAddingAnotherOrgType(OrgType.PublicSector);
            _addOrRemoveOrgSteps.ThenTheNewOrgAddedIsShownInTheAccountOrganisationsList();
            new HomePage(_context, true);
        }

        [Given(@"the Employer logins using existing EI Levy Account")]
        public void GivenTheEmployerLoginsUsingExistingEILevyAccount() => _employerPortalLoginHelper.Login(_context.GetUser<EILevyUser>(), true);
    }
}
