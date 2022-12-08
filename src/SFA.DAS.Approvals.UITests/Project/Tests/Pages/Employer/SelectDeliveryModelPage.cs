using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SelectDeliveryModelPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Select the apprenticeship delivery model";
        protected override By ContinueButton => By.CssSelector("#selectDeliveryModel button");
        private static By FlexiJobRadioButton => By.CssSelector("label[for=DeliveryModelFjaa]");
        private static By EditFlexiJobRadioButton => By.CssSelector("label[for=FlexiJobAgency]");
        private static By RegularRadioButton => By.CssSelector("label[for=DeliveryModelRegular]");
        private static By PortableFlexiJobRadioButton => By.CssSelector("label[for=DeliveryModelFlexible]");

        public SelectDeliveryModelPage(ScenarioContext context) : base(context) { }

        public AddPersonalDetailsPage SelectFlexiJobAgencyDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(FlexiJobRadioButton);
            Continue();
            return new AddPersonalDetailsPage(context);
        }

        public EditTrainingDetailsPage EditDeliveryModelToFlexiAndContinue()
        {
            formCompletionHelper.Click(EditFlexiJobRadioButton);
            Continue();
            return new EditTrainingDetailsPage(context);
        }

        public ProviderAddPersonalDetailsPage ProviderSelectFlexiJobAgencyDeliveryModelAndContinue ()
        {
            formCompletionHelper.Click(FlexiJobRadioButton);
            Continue();
            return new ProviderAddPersonalDetailsPage(context);
        }

        public AddPersonalDetailsPage SelectPortableFlexiJobDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(PortableFlexiJobRadioButton);
            Continue();
            return new AddPersonalDetailsPage(context);
        }

        public ProviderAddPersonalDetailsPage SelectRegularDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(RegularRadioButton);
            Continue();
            return new ProviderAddPersonalDetailsPage(context);
        }

        public EditApprenticeDetailsPage EmployerEditDeliveryModelToRegularAndContinue()
        {
            formCompletionHelper.Click(RegularRadioButton);
            Continue();
            return new EditApprenticeDetailsPage(context);
        }

        public AddPersonalDetailsPage EmployerSelectRegularDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(RegularRadioButton);
            Continue();
            return new AddPersonalDetailsPage(context);
        }

        public ProviderEditApprenticeTrainingDetailsPage ProviderSelectFlexiJobAgencyDeliveryModelAndSubmit()
        {
            formCompletionHelper.Click(EditFlexiJobRadioButton);
            Continue();
            return new ProviderEditApprenticeTrainingDetailsPage(context);
        }

        public ProviderEditApprenticeDetailsPage ProviderEditsDeliveryModelToRegularAndSubmits()
        {
            formCompletionHelper.Click(RegularRadioButton);
            Continue();
            return new ProviderEditApprenticeDetailsPage(context);
        }
    }
}
