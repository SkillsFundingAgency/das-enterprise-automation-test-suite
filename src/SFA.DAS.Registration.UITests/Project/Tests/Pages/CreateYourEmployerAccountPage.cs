using DnsClient;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CreateYourEmployerAccountPage : RegistrationBasePage
    {
        protected override string PageTitle => "Create your employer account";

        public CreateYourEmployerAccountPage(ScenarioContext context) : base(context) => VerifyPage();

        public ChangeYourUserDetailsPage GoToAddYouUserDetailsLink()
        {
            formCompletionHelper.ClickLinkByText("Add your user details");
            return new ChangeYourUserDetailsPage(context);
        }

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

        public AboutYourAgreementPage GoToYourEmployerAgreementLink()
        {
            formCompletionHelper.ClickLinkByText("Your employer agreement");
            return new AboutYourAgreementPage(context);
        }

        public AddATrainingProviderPage GoToTrainingProviderLink()
        {
            formCompletionHelper.ClickLinkByText("Training provider");
            return new AddATrainingProviderPage(context);
        }

        public YourTrainingProvidersPage GoToTrainingProviderPermissionsLink()
        {
            formCompletionHelper.ClickLinkByText("Training provider permissions");
            return new YourTrainingProvidersPage(context);
        }

    }
}
