using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SignInToYourApprenticeshipServiceAccountPage : RegistrationBasePage
    {
        protected override string PageTitle => "Sign in to your apprenticeship service account";

        public SignInToYourApprenticeshipServiceAccountPage(ScenarioContext context) : base(context) { }

        public CreateAnAccountToManageApprenticeshipsPage GoManageApprenticeLandingPage()
        {
            context.Get<TabHelper>().GoToUrl(UrlConfig.EmployerApprenticeshipService_BaseUrl);
            return new CreateAnAccountToManageApprenticeshipsPage(context);
        }
    }
}
