using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class DeleteReservationPage : BasePage
    {
        protected override string PageTitle => "Delete Reservation";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
        private By DeleteRadioButton => By.CssSelector(".govuk-radios__label");
        private By ConfirmButton => By.CssSelector(".govuk-button");

        public DeleteReservationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ReservationSuccessfullyDeletedPage YesDeleteThisReservation()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(DeleteRadioButton, "Delete");
            _formCompletionHelper.ClickElement(ConfirmButton);
            return new ReservationSuccessfullyDeletedPage(_context);
        }
    }
}
