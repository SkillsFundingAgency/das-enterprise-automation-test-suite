using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class PledgeOrganisationNameOptionPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Show organisation name";

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public CreateATransferPledgePage EnterValidOrgNameChoice(bool showOrg)
        {
            SelectOrgName(showOrg);

            return new CreateATransferPledgePage(context);
        }

        private void SelectOrgName(bool showOrg)
        {
            string radioOption = showOrg ? "Yes, show my organisation's name" : "No, hide my organisation's name";

            formCompletionHelper.SelectRadioOptionByText(radioOption);

            Continue();
        }

    }
}