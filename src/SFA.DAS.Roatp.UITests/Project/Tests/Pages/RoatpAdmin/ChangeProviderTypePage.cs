using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class ChangeProviderTypePage : ChangeBasePage
    {
        protected override string PageTitle => $"Change provider type for {objectContext.GetProviderName()}";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By OrganisationTypeIdEmployer => By.Id("OrganisationTypeIdEmployer");

        public ChangeProviderTypePage(ScenarioContext context) : base(context) => _context = context;

        public ResultsFoundPage ConfirmNewProviderTypeAsEmloyer()
        {
            SelectRadioOptionByText("Employer provider");
            formCompletionHelper.SelectFromDropDownByValue(OrganisationTypeIdEmployer, "20");
            Continue();
            return new ResultsFoundPage(_context);
        }

        public ResultsFoundPage ConfirmNewProviderTypeAsMain()
        {
            SelectRadioOptionByText("Main provider");
            Continue();
            return new ResultsFoundPage(_context);
        }
    }
}
