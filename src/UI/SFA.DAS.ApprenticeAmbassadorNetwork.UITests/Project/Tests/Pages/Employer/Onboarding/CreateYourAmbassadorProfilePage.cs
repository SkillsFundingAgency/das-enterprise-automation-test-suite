using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer.Onboarding
{
    public class CreateYourAmbassadorProfilePage(ScenarioContext context) : AanBasePage(context)
    {
        protected override string PageTitle => "Create your ambassador profile";

       // private static By ContinueButton => By.Id("continue-button");

        public HowYouWantToBeInvolvedPage ConfirmYourAmbassadorProfile()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new HowYouWantToBeInvolvedPage(context);
        }
    }
}
