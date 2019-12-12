using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApplicantUnsucessfulPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Are you sure you want to tell this applicant that they have not been accepted?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmApplicantUnsucessfulPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ApplicationUnsuccessfulPage NotifyApplicant()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "notify-candidate-yes");
            _formCompletionHelper.Click(Continue);
            return new ApplicationUnsuccessfulPage(_context);
        }
    }

    
}
