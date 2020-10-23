using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class SelectTheApprenticesPage : EIBasePage
    {
        protected override string PageTitle => "Select the apprentices you want to apply for";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        private By Apprentices => CheckBoxLabels;

        public SelectTheApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        public ConfirmYourApprenticesPage SubmitApprentices()
        {
            foreach (var apprentice in pageInteractionHelper.FindElements(Apprentices))
                formCompletionHelper.ClickElement(apprentice);

            Continue();
            return new ConfirmYourApprenticesPage(_context);
        }
    }
}
