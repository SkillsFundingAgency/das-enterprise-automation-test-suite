using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class SuccessfullyReservedFundingPage : ReservationIdBasePage
    {
        protected override string PageTitle => "You have successfully reserved funding for apprenticeship training";
        protected override By ContinueButton => By.CssSelector("main button");
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
        private By AddApprenticeRadioButton => By.CssSelector("label[for=WhatsNext-add]");

        public SuccessfullyReservedFundingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal HomePage GoToHomePage()
        {
            SelectRadioOptionByForAttribute("WhatsNext-home");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new HomePage(_context);
        }

        private void ChooseToAddApprenticeRadioButton()
        {
            _formCompletionHelper.ClickElement(AddApprenticeRadioButton);
        }

        internal AddAnApprenitcePage AddApprentice()
        {
            ChooseToAddApprenticeRadioButton();
            Continue();
            return new AddAnApprenitcePage(_context);
        }

        public new SuccessfullyReservedFundingPage VerifySucessMessage()
        {
            base.VerifySucessMessage();
            return this;
        }

        internal AddApprenticeDetailsPage AddAnotherApprentice()
        {
            ChooseToAddApprenticeRadioButton();
            Continue();
            return new AddApprenticeDetailsPage(_context);
        }
    }
}
