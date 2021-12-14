using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public abstract class OrganisationSectionsBasePage : EPAOAdmin_BasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        public OrganisationSectionsBasePage(ScenarioContext context) : base(context) { }

        protected OrganisationDetailsPage ReturnToOrganisationDetailsPage(Action action)
        {
            action();
            return new OrganisationDetailsPage(context);
        }
    }
}
