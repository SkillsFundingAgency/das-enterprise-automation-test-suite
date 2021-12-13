using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class EnterUkprnPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What is your organisation's UK provider reference number (UKPRN)?";

        private By UkprnField => By.CssSelector("#UKPRN, #Ukprn");

        public EnterUkprnPage(ScenarioContext context) : base(context) => VerifyPage();

        public ConfirmOrganisationsDetailsPage EnterOrgTypeCompanyProvidersUkprn() => EnterOrgTypeCompanyProvidersUkprn(objectContext.GetUkprn());

        public ConfirmOrganisationsDetailsPage EnterOrgTypeCompanyProvidersUkprn(string ukprn)
        {
            formCompletionHelper.EnterText(pageInteractionHelper.FindElement(UkprnField), ukprn);
            Continue();
            return new ConfirmOrganisationsDetailsPage(context);
        }
    }
}
