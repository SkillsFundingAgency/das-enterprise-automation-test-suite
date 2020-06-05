using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class SuccessfullyReservedFundingPage : ReservationIdBasePage
    {
        protected override string PageTitle => "You have successfully reserved funding for apprenticeship training";
        protected override By ContinueButton => By.CssSelector("main button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AddApprenticeRadioButton => By.CssSelector("label[for=WhatsNext-add]");

        public SuccessfullyReservedFundingPage(ScenarioContext context) : base(context) => _context = context;

        public DynamicHomePages GoToDynamicHomePage()
        {
            SelectRadioOptionByForAttribute("WhatsNext-home");
            formCompletionHelper.ClickElement(ContinueButton);
            return new DynamicHomePages(_context);
        }

        internal AddAnApprenitcePage AddApprentice()
        {
            ChooseToAddApprenticeRadioButton();
            Continue();
            return new AddAnApprenitcePage(_context);
        }

        internal AddApprenticeDetailsPage AddAnotherApprentice()
        {
            ChooseToAddApprenticeRadioButton();
            Continue();
            return new AddApprenticeDetailsPage(_context);
        }

        private void ChooseToAddApprenticeRadioButton() => formCompletionHelper.ClickElement(AddApprenticeRadioButton);
    }
}