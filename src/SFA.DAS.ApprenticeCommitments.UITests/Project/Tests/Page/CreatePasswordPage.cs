using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class CreatePasswordPage : PasswordBasePage
    {
        protected override string PageTitle => "Create password";

        public CreatePasswordPage(ScenarioContext context, string invitationId) : base(context)
        {
            VerifyPage(() =>
            {
                return pageInteractionHelper.InvokeAction(() => 
                {
                    invitationId = string.IsNullOrEmpty(invitationId) ? loginInvitationsSqlDbHelper.GetId(objectContext.GetApprenticeEmail()) : invitationId;

                    context.Get<TabHelper>().OpenInNewTab(UrlConfig.Apprentice_InvitationUrl(invitationId));

                    return pageInteractionHelper.FindElements(PageHeader);
                });

            }, PageTitle);

            new CreatePasswordPage(context);
        }

        private CreatePasswordPage(ScenarioContext context) : base(context) { }
    }
}
