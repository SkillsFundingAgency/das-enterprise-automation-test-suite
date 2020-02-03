using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmApplicantSucessfulPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Are you sure you want to tell this applicant that they have been accepted?";

        private By Continue => By.CssSelector("input[type='submit'][value='Continue']");

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
            formCompletionHelper.Click(Continue);
            return new ApplicationSuccessfulPage(_context);
        }
    }    
}
