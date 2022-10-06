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

        public PersonalDetailsPage SelectFlexiJobAgencyDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(FlexiJobRadioButton);
            Continue();
            return new PersonalDetailsPage(context);
        }

        public ProviderPersonalDetailsPage ProviderSelectFlexiJobAgencyDeliveryModelAndContinue ()
        {
            formCompletionHelper.Click(FlexiJobRadioButton);
            Continue();
            return new ProviderPersonalDetailsPage(context);
        }

        public PersonalDetailsPage SelectPortableFlexiJobDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(PortableFlexiJobRadioButton);
            Continue();
            return new PersonalDetailsPage(context);
        }
    }
}
