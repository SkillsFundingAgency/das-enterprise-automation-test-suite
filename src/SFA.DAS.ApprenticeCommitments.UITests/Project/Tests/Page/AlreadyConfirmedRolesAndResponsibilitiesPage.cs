using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedRolesAndResponsibilitiesPage : ConfirmYourDetailsPage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => SectionHelper.Section5;
        private By SubHeader1 => By.XPath("//h2[@class='govuk-heading-m' and text()='Your responsibilities as an apprentice']");
        private By SubHeader2 => By.XPath("//h2[@class='govuk-heading-m' and text()='Your employer’s responsibilities']");
        private By SubHeader3 => By.XPath("//h2[@class='govuk-heading-m' and text()='Your training provider’s responsibilities']");


        public AlreadyConfirmedRolesAndResponsibilitiesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AlreadyConfirmedRolesAndResponsibilitiesPage VerifySubSectionHeaders()
        {
            VerifyPage(SubHeader1);
            VerifyPage(SubHeader2);
            VerifyPage(SubHeader3);
            return this;
        }

        public ApprenticeOverviewPage NavigateBackToCMADOverviewPage()
        {
            NavigateBack();
            return new ApprenticeOverviewPage(_context);
        }
    }
}
