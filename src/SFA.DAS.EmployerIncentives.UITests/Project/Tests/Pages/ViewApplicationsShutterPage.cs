using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ViewApplicationsShutterPage : EIBasePage
    {
        protected override string PageTitle => $"{ObjectContextExtension.GetOrganisationName(objectContext)} does not have any hire a new apprentice payment applications";

        #region Locators
        private readonly ScenarioContext _context;
        private By ApplyButton => By.LinkText("Apply");
        #endregion

        public ViewApplicationsShutterPage(ScenarioContext context) : base(context) => _context = context;

        public EIStartPage ClickOnApplyButton()
        {
            formCompletionHelper.Click(ApplyButton);
            return new EIStartPage(_context);
        }
    }
}
