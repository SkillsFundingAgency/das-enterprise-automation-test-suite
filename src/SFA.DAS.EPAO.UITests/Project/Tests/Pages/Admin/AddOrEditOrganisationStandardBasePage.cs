using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public abstract class AddOrEditOrganisationStandardBasePage : OrganisationSectionsBasePage
    {
        protected By EffectiveFromDay => By.CssSelector("#EffectiveFromDay");

        protected By EffectiveFromMonth => By.CssSelector("#EffectiveFromMonth");

        protected By EffectiveFromYear => By.CssSelector("#EffectiveFromYear");

        protected By Contacts => By.CssSelector(".govuk-radios__input[name='ContactId']");

        protected By DeliveryAreas => By.CssSelector(".govuk-checkboxes__input[name='DeliveryAreas']");

        protected By Comments => By.CssSelector("#Comments");

        protected AddOrEditOrganisationStandardBasePage(ScenarioContext context) : base(context) => VerifyPage();

        protected void EnterEffectiveFromDetails(DateTime effectiveFrom)
        {
            formCompletionHelper.EnterText(EffectiveFromDay, effectiveFrom.Day.ToString());
            formCompletionHelper.EnterText(EffectiveFromMonth, effectiveFrom.Month.ToString());
            formCompletionHelper.EnterText(EffectiveFromYear, effectiveFrom.Year.ToString());
        }

    }
}
