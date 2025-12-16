using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmYourEmployerPage : ConfirmYourDetailsBasePage
    {
        protected override string PageTitle => "Confirm your employer";

        protected override By ContinueButton => By.CssSelector("#employer-provider-confirm");

        public ConfirmYourEmployerPage(ScenarioContext context, bool verifypage = true, bool verifyserviceheader = true, bool verifyfooterlinks = true) : base(context, verifypage, verifyserviceheader: false, verifyfooterlinks)
        {
            MultipleVerifyPage(
            [
                () => VerifyPage(),
                () => VerifyPage(ConfirmingEntityNamePageHeader, objectContext.GetEmployerName().Replace("  ", " ")),
                () => VerifyPage(EmployerHelpSectionLink),
                () => VerifyPage(EmployerHelpSectionText)
            ]);
        }

        public new ConfirmYourEmployerPage ClickOnConfirmButton()
        {
            base.ClickOnConfirmButton();
            return this;
        }

        public new ConfirmYourEmployerPage VerifyErrorSummaryBoxAndErrorFieldText()
        {
            base.VerifyErrorSummaryBoxAndErrorFieldText();
            return this;
        }
    }
}
