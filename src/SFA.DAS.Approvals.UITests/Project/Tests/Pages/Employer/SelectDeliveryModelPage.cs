using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SelectDeliveryModelPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Select the apprenticeship delivery model";
        protected override By ContinueButton => By.CssSelector("#selectDeliveryModel button");
        private static By FlexiJobRadioButton => By.CssSelector("label[for=DeliveryModelFjaa]");
        private static By EditFlexiJobRadioButton => By.CssSelector("label[for=FlexiJobAgency]");
        private static By RegularRadioButton => By.CssSelector("label[for=DeliveryModelRegular]");
        private static By EditRegularRadioButton => By.XPath("//label[@for='DeliveryModelRegular' or @for='Regular']");
        private static By PortableFlexiJobRadioButton => By.CssSelector("label[for=DeliveryModelFlexible]");

        public SelectDeliveryModelPage(ScenarioContext context) : base(context) { }

        public AddApprenticeDetailsPage SelectFlexiJobAgencyDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(FlexiJobRadioButton);
            Continue();
            return new AddApprenticeDetailsPage(context);
        }

        public EditApprenticeDetailsPage EditDeliveryModelToFlexiAndContinue()
        {
            formCompletionHelper.Click(EditFlexiJobRadioButton);
            Continue();
            return new EditApprenticeDetailsPage(context);
        }

        public ProviderAddApprenticeDetailsPage ProviderSelectFlexiJobAgencyDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(FlexiJobRadioButton);
            Continue();
            return new ProviderAddApprenticeDetailsPage(context);
        }

        public AddApprenticeDetailsPage SelectPortableFlexiJobDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(PortableFlexiJobRadioButton);
            Continue();
            return new AddApprenticeDetailsPage(context);
        }

        public ProviderAddApprenticeDetailsPage SelectRegularDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(RegularRadioButton);
            Continue();
            return new ProviderAddApprenticeDetailsPage(context);
        }

        public EditApprenticeDetailsPage EmployerEditDeliveryModelToRegularAndContinue()
        {
            formCompletionHelper.Click(EditRegularRadioButton);
            Continue();
            return new EditApprenticeDetailsPage(context);
        }

        public AddApprenticeDetailsPage EmployerSelectRegularDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(RegularRadioButton);
            Continue();
            return new AddApprenticeDetailsPage(context);
        }

        public ProviderEditApprenticeDetailsPage ProviderSelectFlexiJobAgencyDeliveryModelAndSubmit()
        {
            formCompletionHelper.Click(EditFlexiJobRadioButton);
            Continue();
            return new ProviderEditApprenticeDetailsPage(context);
        }

        public ProviderEditApprenticeDetailsPage ProviderEditsDeliveryModelToRegularAndSubmits()
        {
            formCompletionHelper.Click(EditRegularRadioButton);
            Continue();
            return new ProviderEditApprenticeDetailsPage(context);
        }

        public EditApprenticeDetailsPage EmployerEditDeliveryModelToFlexiAndContinue()
        {
            formCompletionHelper.Click(EditFlexiJobRadioButton);
            Continue();
            return new EditApprenticeDetailsPage(context);
        }

        public ProviderEditApprenticeDetailsPage ProviderEditsDeliveryModelToFlexiAndSubmits()
        {
            formCompletionHelper.Click(EditFlexiJobRadioButton);
            Continue();
            return new ProviderEditApprenticeDetailsPage(context);
        }
    }
}
