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
        private readonly ScenarioContext _context;
        #endregion

        public DeleteReservationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        internal ReservationSuccessfullyDeletedPage YesDeleteThisReservation()
        {
            SelectRadioOptionByForAttribute("Delete");
            Continue();
            return new ReservationSuccessfullyDeletedPage(_context);
        }
    }
}
