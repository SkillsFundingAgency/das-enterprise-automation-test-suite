using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class AlreadyConfirmedEmployerPage : ConfirmYourDetailsBasePage
    {
        protected override string PageTitle => "Confirm your employer";
        private static string GreenTickTextInfo => "You have confirmed this is your employer";

        public AlreadyConfirmedEmployerPage(ScenarioContext context) : base(context)
        {
            MultipleVerifyPage(
            [
                () => VerifyPage(),
                () => VerifyPage(GreenTickText, GreenTickTextInfo),
                () => VerifyPage(ConfirmingEntityNamePageHeader, objectContext.GetEmployerName().Replace("  ", " ")),
                () => VerifyPage(EmployerHelpSectionLink),
                () => VerifyPage(EmployerHelpSectionText)
            ]);
        }

        public new AlreadyConfirmedEmployerPage ChangeMyAnswerAction()
        {
            base.ChangeMyAnswerAction();
            VerifyPage();
            return this;
        }
    }
}
