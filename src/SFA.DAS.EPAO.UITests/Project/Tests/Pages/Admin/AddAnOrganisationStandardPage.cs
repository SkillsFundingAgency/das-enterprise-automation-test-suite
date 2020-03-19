using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AddAnOrganisationStandardPage : AddOrEditOrganisationStandardBasePage
    {
        protected override string PageTitle => "Add an organisation standard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AddAnOrganisationStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public OrganisationStandardDetailsPage AddStandardsDetails()
        {
            EnterEffectiveFromDetails(ePAOAdminDataHelper.OrgStandardsEffectiveFrom);
            ClickRandomElement(Contacts);
            ClickRandomElement(DeliveryAreas);
            Continue();
            return new OrganisationStandardDetailsPage(_context);
        }
    }
}
