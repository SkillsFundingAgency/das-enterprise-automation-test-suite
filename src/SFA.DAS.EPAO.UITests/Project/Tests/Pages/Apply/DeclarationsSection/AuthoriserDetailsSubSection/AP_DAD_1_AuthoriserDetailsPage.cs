using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.DeclarationsSection.AuthoriserDetailsSubSection
{
    public class AP_DAD_1_AuthoriserDetailsPage : EPAO_BasePage
    {
        protected override string PageTitle => "Authoriser details";
        private readonly ScenarioContext _context;

        #region Locators
        private By CharityNumberTextbox => By.Id("CD-26.1");
        #endregion

        public AP_DAD_1_AuthoriserDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void EnterCharityDetailsAndContinueInRegisteredCharityPage()
        {
            //formCompletionHelper.SelectRadioButton(pageInteractionHelper.FindElement(YesRadioButton));
            formCompletionHelper.EnterText(CharityNumberTextbox, dataHelper.GetRandomNumber(8));
            Continue();
            //return new AP_OD14_RegisterOfRemovedTrusteesPage(_context);
        }
    }
}
