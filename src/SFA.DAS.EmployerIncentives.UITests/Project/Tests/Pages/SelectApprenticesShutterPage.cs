using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class SelectApprenticesShutterPage : EIBasePage
    {
        protected override string PageTitle => $"{ObjectContextExtension.GetOrganisationName(objectContext)} cannot apply for this payment";

        #region Locators
        private By AddApprenticesLink => By.LinkText("add them to their apprenticeship service account.");
        #endregion

        public SelectApprenticesShutterPage(ScenarioContext context) : base(context)  { }

        public AddAnApprenitcePage ClickOnAddApprenticesLink()
        {
            formCompletionHelper.Click(AddApprenticesLink);
            return new AddAnApprenitcePage(_context);
        }
    }
}
