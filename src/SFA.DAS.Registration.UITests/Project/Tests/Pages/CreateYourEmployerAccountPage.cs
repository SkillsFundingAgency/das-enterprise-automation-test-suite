using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CreateYourEmployerAccountPage : RegistrationBasePage
    {
        protected override string PageTitle => "Create your employer account";

        public CreateYourEmployerAccountPage(ScenarioContext context) : base(context) => VerifyPage();

        public HowMuchIsYourOrgAnnualPayBillPage GoToAddPayeLink()
        {
            formCompletionHelper.ClickLinkByText("Add a PAYE scheme");
            return new HowMuchIsYourOrgAnnualPayBillPage(context);
        }

        public SetYourEmployerAccountNamePage GoToSetYourAccountNameLink()
        {
            formCompletionHelper.ClickLinkByText("Set your account name");
            return new SetYourEmployerAccountNamePage(context);
        }

        public AboutYourAgreementPage GoToEmployerAgreementLink()
        {
            formCompletionHelper.ClickLinkByText("Your employer agreement");
            return new AboutYourAgreementPage(context);
        }

        public AddATrainingProviderPage GoToTrainingProviderLink()
        {
            formCompletionHelper.ClickLinkByText("Training provider");
            return new AddATrainingProviderPage(context);
        }

    }
}
