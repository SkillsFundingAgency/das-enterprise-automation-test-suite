using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ReadinessToEngage_Section5
{
    public class PromoteApprentcieshipsToEmployersPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation promote apprenticeships to employers?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public PromoteApprentcieshipsToEmployersPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EnterTextRegardingOrganisationPromoteApprenticeshipsToEmployerAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.OrganisationPromoteApprenticeships);
            return new ApplicationOverviewPage(context);
        }
    }
}
