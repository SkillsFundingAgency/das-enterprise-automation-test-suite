using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.TestDataExport;
using System.Linq;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using System.Collections.Generic;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class SelectEmployersPage : Raav2BasePage
    {

        private List<(string hashedid, string value)> values = new();

        protected override string PageTitle => "Which employer do you want to create a vacancy for?";
        private By SelectItemList => By.CssSelector(".govuk-table .das-button--inline-link");

        private By ListItem(string value) => By.CssSelector($"#select-{value}");

        public SelectEmployersPage(ScenarioContext context) : base(context) { }

        public (CreateAnApprenticeshipAdvertOrVacancyPage, bool) SelectEmployer(string empHashedid)
        {
            List<string> employers = GetEmployers(empHashedid);

            var validemployers = context.Get<ProviderCreateVacancySqlDbHelper>().GetValidHashedId(employers);

            var publichashedid = RandomDataGenerator.GetRandomElementFromListOfElements(validemployers);

            (string hashedidvalue, int noOfLegalEntity) = ((string)publichashedid[0], (int)publichashedid[1]);

            var value = RandomDataGenerator.GetRandomElementFromListOfElements(values.Where(x => x.hashedid == hashedidvalue).ToList()).value;

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ListItem(value));

            if (noOfLegalEntity > 1) noOfLegalEntity = context.Get<RAAV2ProviderPermissionsSqlDbHelper>().GetNoOfValidOrganisations(hashedidvalue);

            objectContext.SetDebugInformation($"Selected employer with hashed id '{hashedidvalue}' who has {noOfLegalEntity} legal entities with provider permission");

            Continue();

            return (new CreateAnApprenticeshipAdvertOrVacancyPage(context), noOfLegalEntity > 1);
        }

        private List<string> GetEmployers(string empHashedid)
        {
            values = GetEmpDetails();

            if (string.IsNullOrEmpty(empHashedid)) return value.Select(x => x.hashedid).ToList();

            return new List<string>() { (empHashedid) };
        }

        private List<(string hashedid, string value)> GetEmpDetails()
        {
            var value = pageInteractionHelper.FindElements(SelectItemList).Select(x => x.GetAttribute("value")).ToList();

            return value.Select(x => (x?.Split('|')[1], x)).ToList();

        }
    }
}
