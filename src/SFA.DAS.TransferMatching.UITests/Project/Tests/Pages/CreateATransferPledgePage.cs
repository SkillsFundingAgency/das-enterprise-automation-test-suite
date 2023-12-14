using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class CreateATransferPledgePage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Create a transfer pledge";

        protected override By ContinueButton => By.CssSelector("#pledge-create-submit");

        private static By ColumnIdentifier => By.CssSelector(".das-task-list__task-tag");

        private string TableIdentifier => ".das-task-list__items";

        private string TableRowIdentifier => ".das-task-list__item";

        public string LocationLink => "Location";
        public string SectorLink => "Sector";
        public string TypeOfJobRoleLink => "Type of job role";
        public string LevelLink => "Level";

        public CreateATransferPledgePage(ScenarioContext context) : base(context) { }

        public PledgeAmountPage GoToPledgeAmountPage()
        {
            formCompletionHelper.ClickLinkByText("Amount you want to pledge");
            return new PledgeAmountPage(context);
        }

        public PledgeOrganisationNameOptionPage GoToPledgeOrganisationNamePageOptionPage()
        {
            formCompletionHelper.ClickLinkByText("Show or hide your organisation's name");
            return new PledgeOrganisationNameOptionPage(context);
        }

        public AddtheLocationPage GoToAddtheLocationPage()
        {
            formCompletionHelper.ClickLinkByText(LocationLink);
            return new AddtheLocationPage(context);
        }

        public ChoosetheSectorsPage GoToChoosetheSectorPage()
        {
            formCompletionHelper.ClickLinkByText(SectorLink);
            return new ChoosetheSectorsPage(context);
        }

        public ChooseTheTypesOfJobPage GoToChooseTheTypesOfJobPage()
        {
            formCompletionHelper.ClickLinkByText(TypeOfJobRoleLink);
            return new ChooseTheTypesOfJobPage(context);
        }

        public ChooseTheLevelPage GoToChooseTheLevelPage()
        {
            formCompletionHelper.ClickLinkByText(LevelLink);
            return new ChooseTheLevelPage(context);
        }

        public Pledge100PercentMatchPage GoToPledge100PercentMatchPage()
        {
            formCompletionHelper.ClickLinkByText("Approve or delay");
            return new Pledge100PercentMatchPage(context);
        }

        public PledgeVerificationPage ContinueToPledgeVerificationPage()
        {
            objectContext.SetPledgeCreatedOn(DateTime.UtcNow);

            Continue();

            return new PledgeVerificationPage(context);
        }

        public string GetAmount(string key) => GetValue(key, 0);

        public string GetCriteriaValue(string key) => GetValue(key, 2);

        private string GetValue(string key, int tableposition) => tableRowHelper.GetColumn(key, ColumnIdentifier, TableIdentifier, TableRowIdentifier, tableposition).Text;
    }
}