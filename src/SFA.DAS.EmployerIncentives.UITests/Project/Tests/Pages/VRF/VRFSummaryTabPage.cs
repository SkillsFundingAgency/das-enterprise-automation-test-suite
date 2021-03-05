using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFSummaryTabPage : VRFBasePage
    {
        protected override string PageTitle => "Organisation details";

        #region Locators
        private readonly ScenarioContext _context;
        protected override By ContinueButton => By.CssSelector(".submitbutton");
        #endregion

        public VRFSummaryTabPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public VRFReceivedDetailsConfirmPage AcknowledgeSummaryDetails()
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                SelectCheckBoxByText("declaration", "I am completing this form with diligence and the information I am providing is accurate, and on behalf of the organisation I work for and/or myself");
                SelectCheckBoxByText("declaration", "The DfE will retain the information provided in accordance with applicable Data Protection laws");
                SelectCheckBoxByText("declaration", "I understand that information submitted to intentionally deceive, mislead and/or commit acts of fraud can have legal and/or criminal ramifications, to which the DfE reserves the right to present evidence in a Court of Law.");
                Continue();
            });
            return new VRFReceivedDetailsConfirmPage(_context);
        }
    }
}
