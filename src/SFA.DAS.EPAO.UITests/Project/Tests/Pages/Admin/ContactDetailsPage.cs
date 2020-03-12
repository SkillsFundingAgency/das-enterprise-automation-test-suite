using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class ContactDetailsPage : OrganisationSectionsBasePage
    {
        protected override string PageTitle => "View contact";

        private By OrganisationLink => By.CssSelector(".govuk-link[href*='view-organisation']");

        public ContactDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public new OrganisationDetailsPage ReturnToOrganisationDetailsPage() => ReturnToOrganisationDetailsPage(() => formCompletionHelper.ClickElement(OrganisationLink));

    }  
}