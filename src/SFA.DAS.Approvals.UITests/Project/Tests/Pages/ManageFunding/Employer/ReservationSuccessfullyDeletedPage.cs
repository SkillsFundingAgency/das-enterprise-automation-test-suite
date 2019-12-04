using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReservationSuccessfullyDeletedPage : BasePage
    {
        protected override string PageTitle => "Reservation successfully deleted";
        private By ReturnToManangeReservationRadioButton => By.CssSelector(".govuk-radios__label");
        private By ConfirmButton => By.CssSelector(".govuk-button");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ReservationSuccessfullyDeletedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ReservationSuccessfullyDeletedPage ChooseReturnToManageReservationRadioButton()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ReturnToManangeReservationRadioButton, "Manage");
            return new ReservationSuccessfullyDeletedPage(_context);
        }

        public YourFundingReservationsPage ClickConfirmButton()
        {
            _formCompletionHelper.ClickElement(ConfirmButton);
            return new YourFundingReservationsPage(_context);
        }
    }
}
