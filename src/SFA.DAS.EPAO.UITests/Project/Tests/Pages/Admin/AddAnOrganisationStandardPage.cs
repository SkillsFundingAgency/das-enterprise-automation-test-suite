using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AddAnOrganisationStandardPage : OrganisationSectionsBasePage
    {
        protected override string PageTitle => "Add an organisation standard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By EffectiveFromDay => By.CssSelector("#EffectiveFromDay");
        
        private By EffectiveFromMonth => By.CssSelector("#EffectiveFromMonth");
        
        private By EffectiveFromYear => By.CssSelector("#EffectiveFromYear");

        private By Contacts => By.CssSelector(".govuk-radios__input[name='ContactId']");

        private By DeliveryAreas => By.CssSelector(".govuk-checkboxes__input[name='DeliveryAreas']");

        public AddAnOrganisationStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ViewOrganisationStandardPage AddStandardsDetails()
        {
            var effectiveFrom = ePAOAdminDataHelper.StandardsEffectiveFrom.AddDays(35);
            formCompletionHelper.EnterText(EffectiveFromDay, effectiveFrom.Day.ToString());
            formCompletionHelper.EnterText(EffectiveFromMonth, effectiveFrom.Month.ToString());
            formCompletionHelper.EnterText(EffectiveFromYear, effectiveFrom.Year.ToString());
            ClickRandomElement(Contacts);
            ClickRandomElement(DeliveryAreas);
            Continue();
            return new ViewOrganisationStandardPage(_context);
        }
    }
}
