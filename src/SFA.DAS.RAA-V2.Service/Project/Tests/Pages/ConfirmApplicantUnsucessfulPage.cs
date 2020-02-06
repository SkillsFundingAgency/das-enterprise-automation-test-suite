using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmApplicantUnsucessfulPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Are you sure you want to tell this applicant that they have not been accepted?";

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmApplicantUnsucessfulPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ApplicationUnsuccessfulPage NotifyApplicant()
        {
            SelectRadioOptionByForAttribute("notify-candidate-yes");
            Continue();
            return new ApplicationUnsuccessfulPage(_context);
        }
    }

    
}
