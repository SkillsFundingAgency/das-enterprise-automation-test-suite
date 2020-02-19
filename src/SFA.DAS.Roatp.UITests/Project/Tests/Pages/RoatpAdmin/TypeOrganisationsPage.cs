using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public class TypeOrganisationsPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Choose a type of organisation for";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".govuk-button[value='Continue']");

        public TypeOrganisationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ApplicationDateDeterminedPage SubmitIndependentTrainingProvider()
        {
            SelectRadioOptionByText("Independent training provider");
            Continue();
            return new ApplicationDateDeterminedPage(_context);
        }

    }
}
