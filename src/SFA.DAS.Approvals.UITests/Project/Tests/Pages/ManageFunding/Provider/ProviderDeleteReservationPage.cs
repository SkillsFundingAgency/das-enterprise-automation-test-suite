using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderDeleteReservationPage : BasePage
    {

        protected override string PageTitle => "Delete Reservation";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ProviderDeleteReservationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By DeleteRadioButton => By.CssSelector(".govuk-radios__label");
        private By ConfirmButton => By.CssSelector(".govuk-button");

        internal ProviderReservationSuccessfullyDeletedPage YesDeleteThisReservation()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(DeleteRadioButton, "Delete");
            _formCompletionHelper.ClickElement(ConfirmButton);
            return new ProviderReservationSuccessfullyDeletedPage(_context);
        }
    }
}
