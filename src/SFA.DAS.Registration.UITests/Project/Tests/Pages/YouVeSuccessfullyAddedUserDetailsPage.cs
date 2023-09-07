using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouVeSuccessfullyAddedUserDetailsPage : RegistrationBasePage
    {
        protected override string PageTitle => "You've successfully added user details";
        public YouVeSuccessfullyAddedUserDetailsPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }

        public CreateYourEmployerAccountPage ClickContinueButtonToAcknowledge()
        {
            Continue();
            return new CreateYourEmployerAccountPage(context);
        }
    }
}
