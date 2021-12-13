using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class ParentCompanyDetailsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Enter your organisation's UK ultimate parent company details";

        private By CompanyNumberField => By.Id("YO-21");

        private By CompanyNameField => By.Id("YO-22");

        public ParentCompanyDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

        public IcoRegistrationNumberPage EnterParentCompanyDetailsAndContinue()
        {
            formCompletionHelper.EnterText(CompanyNumberField, applydataHelpers.CompanyNumber);
            formCompletionHelper.EnterText(CompanyNameField, applydataHelpers.CompanyName);
            Continue();
            return new IcoRegistrationNumberPage(_context);
        }
        public IcoRegistrationNumberPage ClickContinueForParentCompanyDetails()
        {
            Continue();
            return new IcoRegistrationNumberPage(_context);
        }
    }
}
