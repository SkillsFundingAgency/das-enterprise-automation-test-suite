using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class EmployerAmbassadorApplicationPage : AanBasePage
    {
        protected override string PageTitle => "Apply to become an employer ambassador for a";

        private By StartButton => By.Id("start-now");

        public EmployerAmbassadorApplicationPage(ScenarioContext context) : base(context) => VerifyPage();

        public TermsAndConditionsPage StartEmployerAmbassadorApplication()
        {
            formCompletionHelper.Click(StartButton);
            return new TermsAndConditionsPage(context);
        }
    }
}
