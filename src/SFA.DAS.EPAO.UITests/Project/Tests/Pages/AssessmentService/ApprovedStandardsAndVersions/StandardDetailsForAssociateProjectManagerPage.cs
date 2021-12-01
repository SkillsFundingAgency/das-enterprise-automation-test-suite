using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class StandardDetailsForAssociateProjectManagerPage : EPAO_BasePage
    {
        protected override string PageTitle => "Associate project manager";

        private readonly ScenarioContext _context;

        #region Locators
        private By AssociateProjectManagerOptInLinkForVersion1_1 => By.LinkText("Opt into standard version");
        #endregion

        public StandardDetailsForAssociateProjectManagerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ConfirmOptInForAssociateProjectManagerPage ClickOnAssociateProjectManagerOptInLinkForVersion1_1()
        {
            formCompletionHelper.ClickElement(AssociateProjectManagerOptInLinkForVersion1_1);
            return new ConfirmOptInForAssociateProjectManagerPage(_context);
        }
    }
}