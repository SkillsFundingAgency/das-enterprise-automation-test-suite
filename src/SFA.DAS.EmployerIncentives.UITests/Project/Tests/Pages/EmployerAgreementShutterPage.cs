using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class EmployerAgreementShutterPage : EIBasePage
    {
        protected override string PageTitle => $"{ObjectContextExtension.GetOrganisationName(objectContext)} needs to accept the employer agreement";

        #region Locators
        private By ViewAgreementButton => By.LinkText("View agreement");
        #endregion

        public EmployerAgreementShutterPage(ScenarioContext context) : base(context)  { }

        public YourOrganisationsAndAgreementsPage ClickOnViewAgreementButton()
        {
            formCompletionHelper.Click(ViewAgreementButton);
            return new YourOrganisationsAndAgreementsPage(context);
        }

        public HomePage ClickOnReturnToAccountHomeLink()
        {
            formCompletionHelper.Click(ReturnToAccountHomeCTA);
            return new HomePage(context);
        }
    }
}
