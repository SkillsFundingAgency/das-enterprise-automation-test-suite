using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.StubPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    internal class RoatpApplyLoginHelpers(ScenarioContext context)
    {
        internal void SubmitValidUserDetails() => ApplyNow().SubmitValidUserDetails().Continue();

        internal void CreateAnAccount()
        {
            var datahelper = context.Get<RoatpApplyCreateUserDataHelper>();

            ApplyNow().CreateAccount(datahelper.CreateAccountEmail, datahelper.CreateAccountIdOrUserRef).Continue();

            new StubAddYourUserDetailsPage(context).EnterNameAndContinue(datahelper);
        }

        private StubSignInApplyPage ApplyNow() => new RoatpServiceStartPage(context).ClickApplyNow();
    }
}
