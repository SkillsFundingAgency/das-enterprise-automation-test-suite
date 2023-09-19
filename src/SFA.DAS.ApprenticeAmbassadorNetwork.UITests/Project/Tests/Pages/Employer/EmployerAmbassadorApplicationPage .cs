using Polly;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Apprentice;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer
{
    public class EmployerAmbassadorApplicationPage : AanBasePage
    {
        protected override string PageTitle => "Apply to become an employer ambassador for";

        private By StartButton => By.Id("start-now");

        public EmployerAmbassadorApplicationPage(ScenarioContext context) : base(context) => VerifyPage();

        public TermsAndConditionsOfEmployerPage StartEmployerAmbassadorApplication()
        {
            formCompletionHelper.Click(StartButton);
            return new TermsAndConditionsOfEmployerPage(context);
        }
    }
}
