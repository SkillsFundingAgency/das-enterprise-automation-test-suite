using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ResetPasswordPage : PasswordBasePage
    {
        protected override string PageTitle => "Reset password";

        public ResetPasswordPage(ScenarioContext context, (string clientId, string requestId) id) : base(context)
        {
            VerifyPage(() =>
            {
                id = (string.IsNullOrEmpty(id.clientId) || string.IsNullOrEmpty(id.requestId)) ? loginInvitationsSqlDbHelper.GetApprenticeResetLoginData(objectContext.GetApprenticeEmail()) : id;

                return pageInteractionHelper.InvokeAction(() =>
                {
                    context.Get<TabHelper>().OpenInNewTab(UrlConfig.Apprentice_ResetPasswordUrl(id.clientId, id.requestId));

                    return pageInteractionHelper.FindElements(PageHeader);
                });

            }, PageTitle);

            _validPassword = $"{apprenticeCommitmentsConfig.AC_AccountPassword}!%&";
        }    
    }
}
