using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class SelectDeliveryModelPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Select the apprenticeship delivery model";

        protected override By ContinueButton => By.CssSelector("#selectDeliveryModel button");

        private By RegularJobRadioButton => By.CssSelector("label[for=DeliveryModelRegular]");
        private By FlexiJobRadioButton => By.CssSelector("label[for=DeliveryModelFjaa]");

        public SelectDeliveryModelPage(ScenarioContext context) : base(context) { }

        public AddApprenticeDetailsPage SelectFlexiJobAgencyDeliveryModelAndContinue()
        {
            formCompletionHelper.Click(FlexiJobRadioButton);

            Continue();

            return new AddApprenticeDetailsPage(context);
        }


    }
}
