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
        private static By PortableFlexiJobRadioButton => By.CssSelector("label[for=DeliveryModelFlexible]");

        public SelectDeliveryModelPage(ScenarioContext context) : base(context) { }

        public AddPersonalDetailsPage SelectFlexiJobAgencyDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(FlexiJobRadioButton);
            Continue();
            return new AddPersonalDetailsPage(context);
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
    }
}
