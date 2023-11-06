using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign;
using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.Login.Service;
using SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages.Moderation;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MS_Moderation_Steps
    {
        private readonly DfeEsfaAdminLoginStepsHelper _dfeEsfaAdminLoginStepsHelper;
        private ScenarioContext _context;
        private Moderation_ProviderDetailsPage _moderation_ProviderDetailsPage;
        private Moderation_UpdateProviderPage _moderation_UpdateProviderPage;

        public MS_Moderation_Steps(ScenarioContext context)
        {
            _context = context;
            _dfeEsfaAdminLoginStepsHelper = new DfeEsfaAdminLoginStepsHelper(context);
        }

        [Given(@"the tribal user searches for provider with UKPRN")]
        public void GivenTheTribalUserSearchesForProviderWithUKPRN()
        {
            _context.Get<TabHelper>().GoToUrl(UrlConfig.Admin_BaseUrl);

            _dfeEsfaAdminLoginStepsHelper.SubmitValidLoginDetails(_context.GetUser<EsfaAdminUser>());

            _moderation_ProviderDetailsPage = new Moderation_HomePage(_context).SearchForTrainingProvider().SearchTrainingProviderByUkprn(MS_DataHelper.UKPRN);
        }

        [When(@"the tribal user chooses to change the provider details")]
        public void WhenTheTribalUserChoosesToChangeTheProviderDetails()
        {
            _moderation_UpdateProviderPage = _moderation_ProviderDetailsPage.ChangeProviderDetail();
        }

        [Then(@"the tribal user is allowed to make the change")]
        public void ThenTheTribalUserIsAllowedToMakeTheChange()
        {
            _moderation_UpdateProviderPage.EnterUpdateDescriptionAndContinue()
                .ContinueOnCheckProviderUpdatePage()
                .ChangeProviderDetail()
                .VerifyUpdateDescriptionText();
        }
    }
}
