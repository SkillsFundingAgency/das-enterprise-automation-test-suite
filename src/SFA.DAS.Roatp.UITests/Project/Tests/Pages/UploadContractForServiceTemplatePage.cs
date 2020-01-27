using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class UploadContractForServiceTemplatePage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's contract for services template with employers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UploadContractForServiceTemplatePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage ContractForServicesTemplateFileUploadAndContinue()
        {
            UploadFile();
            return new ApplicationOverviewPage(_context);
        }
    }

}
