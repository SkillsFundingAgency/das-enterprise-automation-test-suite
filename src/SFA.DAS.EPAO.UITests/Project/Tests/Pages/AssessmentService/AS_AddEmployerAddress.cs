using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_AddEmployerAddress : BasePage
    {
        protected override string PageTitle => "Add the employer's address";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By CompanyNameTextBox => By.Id("Employer");
        private By AddressLine1TextBox => By.Id("AddressLine1");
        private By AddressLine2TextBox => By.Id("AddressLine2");
        private By AddressLine3TextBox => By.Id("AddressLine3");
        private By TownOrCityTextBox => By.Id("City");
        private By PostCodeTextBox => By.Id("Postcode");
        #endregion

        public AS_AddEmployerAddress(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_ConfirmAddressPage EnterEmployerAddressAndContinue()
        {
            _formCompletionHelper.EnterText(CompanyNameTextBox, "ESFA");
            _formCompletionHelper.EnterText(AddressLine1TextBox, "5");
            _formCompletionHelper.EnterText(AddressLine2TextBox, "QuintonRoad");
            _formCompletionHelper.EnterText(AddressLine3TextBox, "C House");
            _formCompletionHelper.EnterText(TownOrCityTextBox, "Coventry");
            _formCompletionHelper.EnterText(PostCodeTextBox, "CV1 2WT");
            Continue();
            return new AS_ConfirmAddressPage(_context);
        }
    }
}
