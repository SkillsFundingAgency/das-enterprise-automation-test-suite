using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReservationSuccessfullyDeletedPage : BasePage
    {
        protected override string PageTitle => "Reservation successfully deleted";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");
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
            SelectRadioOptionByForAttribute("Manage");
            return new ReservationSuccessfullyDeletedPage(_context);
        }

        public ManageFundingHomePage ClickConfirmButton()
        {
            Continue();
            return new ManageFundingHomePage(_context);
        }
    }
}
