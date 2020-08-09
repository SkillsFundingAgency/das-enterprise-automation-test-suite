using TechTalk.SpecFlow;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RegistrationEISteps
    {
        private readonly ScenarioContext _context;
        private readonly AddOrRemoveOrgSteps _addOrRemoveOrgSteps;

        public RegistrationEISteps(ScenarioContext context)
        {
            _context = context;
            _addOrRemoveOrgSteps = new AddOrRemoveOrgSteps(_context);
        }

        [Given(@"the Employer adds another legal entity")]
        public void GivenTheEmployerAddsAnotherLegalEntity()
        {
            _addOrRemoveOrgSteps.WhenTheEmployerInitiatesAddingAnotherOrgType(OrgType.PublicSector);
            _addOrRemoveOrgSteps.ThenTheNewOrgAddedIsShownInTheAccountOrganisationsList();
            new HomePage(_context, true);
        }
    }
}
