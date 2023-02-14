using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin
{
    public class ChangeProviderTypePage : ChangeBasePage
    {
        protected override string PageTitle => $"Change provider type for {objectContext.GetProviderName()}";

        private By OrganisationTypeIdEmployer => By.Id("OrganisationTypeIdEmployer");

        public ChangeProviderTypePage(ScenarioContext context) : base(context) { }

        public ResultsFoundPage ConfirmNewProviderTypeAsEmloyer()
        {
            SelectRadioOptionByText("Employer provider");
            formCompletionHelper.SelectFromDropDownByValue(OrganisationTypeIdEmployer, "20");
            Continue();
            return new ResultsFoundPage(context);
        }

        public ResultsFoundPage ConfirmNewProviderTypeAsMain()
        {
            SelectRadioOptionByText("Main provider");
            Continue();
            return new ResultsFoundPage(context);
        }
    }
}
