using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApplicantSucessfulPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Are you sure you want to tell this applicant that they have been accepted?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmApplicantSucessfulPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ApplicationSuccessfulPage NotifyApplicant()
        {
            SelectRadioOptionByForAttribute("notify-candidate-yes");
            Continue();
            return new ApplicationSuccessfulPage(_context);
        }
    }    
}
