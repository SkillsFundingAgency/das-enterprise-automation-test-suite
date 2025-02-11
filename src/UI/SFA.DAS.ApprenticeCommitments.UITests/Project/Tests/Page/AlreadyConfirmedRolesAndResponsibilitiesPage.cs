using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedRolesAndResponsibilitiesPage : ConfirmYourDetailsBasePage
    {
        protected override string PageTitle => OverviewPageHelper.Section5;
        private static By SubHeader1 => By.XPath("//h2[@class='govuk-heading-m' and text()='Your responsibilities as an apprentice']");
        private static By SubHeader2 => By.XPath("//h2[@class='govuk-heading-m' and text()=\"Your employer's responsibilities\"]");
        private static By SubHeader3 => By.XPath("//h2[@class='govuk-heading-m' and text()=\"Your training provider's responsibilities\"]");

        public AlreadyConfirmedRolesAndResponsibilitiesPage(ScenarioContext context) : base(context) => VerifyPage();

        public AlreadyConfirmedRolesAndResponsibilitiesPage VerifySubSectionHeaders()
        {
            VerifyElement(SubHeader1);
            VerifyElement(SubHeader2);
            VerifyElement(SubHeader3);
            return this;
        }

        public ApprenticeOverviewPage NavigateBackToCMADOverviewPage()
        {
            NavigateBack();
            return new ApprenticeOverviewPage(context);
        }

        public FullyConfirmedOverviewPage NavigateBackToFullyConfirmedOverviewPage()
        {
            NavigateBack();
            return new FullyConfirmedOverviewPage(context);
        }
    }
}
