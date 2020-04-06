using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class EditAnOrganisationStandardPage : AddOrEditOrganisationStandardBasePage
    {
        protected override string PageTitle => "Edit an organisation standard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EditAnOrganisationStandardPage(ScenarioContext context) : base(context) => _context = context;

        public OrganisationStandardDetailsPage EditStandardsDetails()
        {
            EnterEffectiveFromDetails(ePAOAdminDataHelper.OrgStandardsEffectiveFrom.AddDays(5));
            formCompletionHelper.EnterText(Comments, "updated effective from details");
            Continue();
            return new OrganisationStandardDetailsPage(_context);
        }
    }
}
