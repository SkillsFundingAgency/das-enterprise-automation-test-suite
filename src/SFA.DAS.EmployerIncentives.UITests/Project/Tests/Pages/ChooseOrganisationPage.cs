using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ChooseOrganisationPage : EIBasePage
    {
        protected override string PageTitle => "Choose organisation";

        private readonly ScenarioContext _context;
        
        public ChooseOrganisationPage(ScenarioContext context) : base(context) => _context = context;

        public EIHubPage SelectFirstEntityInChooseOrgPageAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText(objectContext.GetOrganisationName());
            formCompletionHelper.Click(ContinueButton);
            return new EIHubPage(_context);
        }
    }
}