using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System;

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

        public ProviderAddApprenticeDetailsPage ProviderSelectFlexiJobAgencyDeliveryModelAndContinue ()
        {
            formCompletionHelper.Click(FlexiJobRadioButton);
            Continue();
            return new ProviderAddApprenticeDetailsPage(context);
        }

        public AddPersonalDetailsPage SelectPortableFlexiJobDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(PortableFlexiJobRadioButton);
            Continue();
            return new AddPersonalDetailsPage(context);
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
            formCompletionHelper.Click(EditRegularRadioButton); 
            Continue();
            return new ProviderEditApprenticeDetailsPage(context);
        }
    }
}
