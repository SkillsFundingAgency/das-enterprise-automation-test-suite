using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticesHomePage : InterimEmployerBasePage
    {
        protected override string PageTitle => "Apprentices";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AddAnApprenticeLink => By.LinkText("Add an apprentice");
        private By YourCohortsLink => By.LinkText("Your cohorts");
        private By ManageYourApprenticesLink => By.LinkText("Manage your apprentices");
        private By SetPaymentOrder => By.LinkText("Set payment order");
        private By ReportPublicSectorApprenticeshipTarget => By.LinkText("Report public sector apprenticeship target");

        protected override string Linktext => "Apprentices";

        public ApprenticesHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
        }

        public AddAnApprenitcePage AddAnApprentice()
        {
            formCompletionHelper.ClickElement(AddAnApprenticeLink);
            return new AddAnApprenitcePage(_context);
        }

        public YourCohortRequestsPage ClickYourCohortsLink()
        {
            formCompletionHelper.ClickElement(YourCohortsLink);
            return new YourCohortRequestsPage(_context);
        }

        public ManageYourApprenticesPage ClickManageYourApprenticesLink()
        {
            formCompletionHelper.ClickElement(ManageYourApprenticesLink);
            return new ManageYourApprenticesPage(_context);
        }

        public SetpaymentOrderPage ClickSetPaymentOrderLink()
        {
            formCompletionHelper.ClickElement(SetPaymentOrder);
            return new SetpaymentOrderPage(_context);
        }

        public ReportPublicSectorApprenticeshipTargetPage ClickReportPublicSectorApprenticeshipTargetLink()
        {
            formCompletionHelper.ClickElement(ReportPublicSectorApprenticeshipTarget);
            return new ReportPublicSectorApprenticeshipTargetPage(_context);
        }
    }
}

